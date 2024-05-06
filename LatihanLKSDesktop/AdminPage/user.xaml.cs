using LatihanLKSDesktop.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static LatihanLKSDesktop.Model.BaseModel;

namespace LatihanLKSDesktop.AdminPage
{
    /// <summary>
    /// Interaction logic for user.xaml
    /// </summary>
    public partial class user : Page
    {
        public user()
        {
            InitializeComponent();
            input_tipe_user.SelectedIndex = 0;
            input_id.Clear();
            RefreshDatagrid();
        }

        void RefreshDatagrid(string query = $"SELECT id_user, tipe_user, nama, telepon, alamat, username, password FROM tbl_user EXCEPT SELECT id_user,tipe_user,nama,telepon,alamat,username,password FROM tbl_user WHERE tipe_user='admin';")
        {
            datagrid.Items.Clear();
            SqlConnection conn = new SqlConnection(Settings.Default.conn);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                UserModel data = new UserModel();
                data.id_user = reader.GetValue(0).ToString();
                data.tipe_user = reader.GetValue(1).ToString();
                data.nama = reader.GetValue(2).ToString();
                data.telepon = reader.GetValue(3).ToString();
                data.alamat = reader.GetValue(4).ToString();
                data.username = reader.GetValue(5).ToString();
                data.password = reader.GetValue(6).ToString();
                datagrid.Items.Add(data);
            }
            cmd.Dispose();
            reader.Close();
            conn.Close();
        }

        private void Search(object sender, TextChangedEventArgs e)
        {
            if (input_search.Text.Length > 0)
            {
                RefreshDatagrid($"SELECT id_user, tipe_user, nama, telepon, alamat, username, password FROM tbl_user WHERE nama LIKE '{input_search.Text}%' EXCEPT SELECT id_user,tipe_user,nama,telepon,alamat,username,password FROM tbl_user WHERE nama LIKE '{input_search.Text}%' AND tipe_user='admin';");
            }else
            {
                RefreshDatagrid();
            }
        }

        private void AddUser(object sender, RoutedEventArgs e)
        {
            if (input_tipe_user.Text == "" || input_nama.Text == "" || input_telepon.Text == "" || input_alamat.Text == "" || input_username.Text == "" || input_password.Text == "")
            {
                MessageBox.Show("Maaf, semua kolom harus diisi untuk melanjutkan registrasi user!");
            }else
            {
                if (isExist(input_username.Text))
                {
                    MessageBox.Show("Maaf, pengguna dengn username tersebut sudah terdaftar!");
                }else
                {
                    MessageBoxResult result = MessageBox.Show("Apakah anda yakin data sudah sesuai?", "Konfirmasi", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
                    if (result == MessageBoxResult.Yes)
                    {
                        SqlConnection conn = new SqlConnection(Settings.Default.conn);
                        SqlCommand cmd = new SqlCommand($"INSERT INTO tbl_user(tipe_user, nama, telepon, alamat, username, password) VALUES('{input_tipe_user.Text.ToLower()}', '{input_nama.Text}', '{input_telepon.Text}', '{input_alamat.Text}', '{input_username.Text}', '{input_password.Text}');", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        conn.Close();
                        RefreshDatagrid();
                        Reset();
                    }
                }
            }
        }

        bool isExist(string username)
        {
            int index = 0;
            SqlConnection conn = new SqlConnection(Settings.Default.conn);
            SqlCommand cmd = new SqlCommand($"SELECT * FROM tbl_user WHERE username='{username}';", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                index++;
            }
            cmd.Dispose();
            reader.Close();
            conn.Close();
            if (index == 0)
            {
                return false;
            }else
            {
                return true;
            }
        }

        void Reset()
        {
            input_tipe_user.SelectedIndex = 0;
            input_nama.Clear();
            input_telepon.Clear();
            input_alamat.Clear();
            input_username.Clear();
            input_password.Clear();
            input_id.Clear();
        }

        private void TakeData(object sender, MouseButtonEventArgs e)
        {
            UserModel data = datagrid.SelectedValue as UserModel;
            if (data.tipe_user == "gudang")
            {
                input_tipe_user.SelectedIndex = 0;
            }else if (data.tipe_user == "kasir")
            {
                input_tipe_user.SelectedIndex = 1;
            }
            input_nama.Text = data.nama;
            input_telepon.Text = data.telepon;
            input_alamat.Text = data.alamat;
            input_username.Text = data.username;
            input_password.Text = data.password;
            input_id.Text = data.id_user;
        }

        private void EditUser(object sender, RoutedEventArgs e)
        {
            if(input_id.Text == "")
            {
                MessageBox.Show("Maaf, anda belum memilih data dari database");
            }else if (input_tipe_user.Text == "" || input_nama.Text == "" || input_telepon.Text == "" || input_alamat.Text == "" || input_username.Text == "" || input_password.Text == "")
            {
                MessageBox.Show("Maaf, semua kolom harus diisi");
            }else
            {
                MessageBoxResult result = MessageBox.Show("Apakah anda yakin ingin mengubah dat ini?", "Konfirmasi", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
                if (result == MessageBoxResult.Yes)
                {
                    SqlConnection conn = new SqlConnection(Settings.Default.conn);
                    SqlCommand cmd = new SqlCommand($"UPDATE tbl_user SET tipe_user='{input_tipe_user.Text.ToLower()}', nama='{input_nama.Text}', alamat='{input_alamat.Text}', telepon='{input_telepon.Text}', username='{input_username.Text}', password='{input_password.Text}' WHERE id_user={input_id.Text}", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();
                    RefreshDatagrid();
                    Reset();
                }
            }
        }

        private void DeleteUser(object sender, RoutedEventArgs e)
        {
            if (input_id.Text == "")
            {
                MessageBox.Show("Maaf, anda belum memilih data dari database");
            }
            else if (input_tipe_user.Text == "" || input_nama.Text == "" || input_telepon.Text == "" || input_alamat.Text == "" || input_username.Text == "" || input_password.Text == "")
            {
                MessageBox.Show("Maaf, semua kolom harus diisi");
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Apakah anda yakin ingin menghapus dat ini?", "Konfirmasi", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
                if (result == MessageBoxResult.Yes)
                {
                    SqlConnection conn = new SqlConnection(Settings.Default.conn);
                    SqlCommand cmd = new SqlCommand($"DELETE FROM tbl_user WHERE id_user={input_id.Text}", conn);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Dispose();
                    conn.Close();
                    RefreshDatagrid();
                    Reset();
                }
            }
        }
    }
}
