using LatihanLKSDesktop.Properties;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
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
using System.Windows.Shapes;
using static LatihanLKSDesktop.Model.BaseModel;

namespace LatihanLKSDesktop
{
    /// <summary>
    /// Interaction logic for Gudang.xaml
    /// </summary>
    public partial class Gudang : Window
    {
        public Gudang()
        {
            InitializeComponent();
            RefreshDatagrid();
            input_id.Text = "";
        }

        void RefreshDatagrid(string query = $"SELECT id_barang, kode_barang, nama_barang, expired_date, jumlah_barang, satuan, harga_satuan FROM tbl_barang;")
        {
            datagrid.Items.Clear();
            SqlConnection conn = new SqlConnection(Settings.Default.conn);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                BarangModel data = new BarangModel();
                data.id_barang = reader.GetValue(0).ToString();
                data.kode_barang = reader.GetValue(1).ToString();
                data.nama_barang = reader.GetValue(2).ToString();
                data.expired_date = reader.GetValue(3).ToString();
                data.jumlah_barang = long.Parse(reader.GetValue(4).ToString());
                data.satuan = reader.GetValue(5).ToString();
                data.harga_satuan = long.Parse(reader.GetValue(6).ToString());
                datagrid.Items.Add(data);
            }
            cmd.Dispose();
            reader.Close();
            conn.Close();
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            Settings.Default.credential = "";
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Search(object sender, TextChangedEventArgs e)
        {

            if (input_search.Text.Length > 0)
            {
                RefreshDatagrid($"SELECT id_barang, kode_barang, nama_barang, expired_date, jumlah_barang, satuan, harga_satuan FROM tbl_barang WHERE nama_barang LIKE '{input_search.Text}%';");
            }
            else
            {
                RefreshDatagrid();
            }
        }

        private void AddBarang(object sender, RoutedEventArgs e)
        {
            long a = 0;
            if (input_kode_barang.Text == "" || input_nama_barang.Text == "" || input_expired_date.Text == "" || input_jumlah_barang.Text == "" || input_satuan.Text == "" || input_harga_satuan.Text == "")
            {
                MessageBox.Show("Maaf, semua kolom harus diisi untuk melanjutkan penyimpanan barang!");
            }
            else if (!long.TryParse(input_jumlah_barang.Text, out a) || !long.TryParse(input_harga_satuan.Text, out a))
            {
                MessageBox.Show("Maaf, kolom jumlah barang dan harga satuan hanya boleh diisi dengan angka!");
            }
            else
            {
                long jumlah_barang = isExist();
                if (jumlah_barang > 0)
                {
                    MessageBoxResult result = MessageBox.Show("Apakah anda yakin ingin menambah barang ini?", "Konfirmasi", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
                    if (result == MessageBoxResult.Yes)
                    {
                        SqlConnection conn = new SqlConnection(Settings.Default.conn);
                        SqlCommand cmd = new SqlCommand($"UPDATE tbl_barang set jumlah_barang={jumlah_barang + long.Parse(input_jumlah_barang.Text)} WHERE kode_barang='{input_kode_barang.Text}';", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        conn.Close();
                        RefreshDatagrid();
                        Reset();
                    }
                }
                else
                {
                    MessageBoxResult result = MessageBox.Show("Apakah anda yakin data sudah sesuai?", "Konfirmasi", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
                    if (result == MessageBoxResult.Yes)
                    {

                        string ex_date = $"{input_expired_date.SelectedDate.Value.ToString().Split("/")[2].Split(" ")[0]}-{input_expired_date.SelectedDate.Value.ToString().Split("/")[1]}-{input_expired_date.SelectedDate.Value.ToString().Split("/")[0]}";
                        SqlConnection conn = new SqlConnection(Settings.Default.conn);
                        SqlCommand cmd = new SqlCommand($"INSERT INTO tbl_barang(kode_barang, nama_barang, expired_date, jumlah_barang, satuan, harga_satuan) VALUES('{input_kode_barang.Text}', '{input_nama_barang.Text}', '{ex_date}', {input_jumlah_barang.Text}, '{input_satuan.Text.ToLower()}', {input_harga_satuan.Text});", conn);
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

        long isExist()
        {
            long index = 0;
            SqlConnection conn = new SqlConnection(Settings.Default.conn);
            SqlCommand cmd = new SqlCommand($"SELECT jumlah_barang FROM tbl_barang WHERE kode_barang='{input_kode_barang.Text}';", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                index = long.Parse(reader.GetValue(0).ToString());
            }
            cmd.Dispose();
            reader.Close();
            conn.Close();
            return index;
        }

        private void EditBarang(object sender, RoutedEventArgs e)
        {
            long a = 0;
            if (input_id.Text == "")
            {
                MessageBox.Show("Maaf, anda belum memilih data dari database");
            }
            else if (input_kode_barang.Text == "" || input_nama_barang.Text == "" || input_expired_date.Text == "" || input_jumlah_barang.Text == "" || input_satuan.Text == "" || input_harga_satuan.Text == "")
            {
                MessageBox.Show("Maaf, semua kolom harus diisi untuk melanjutkan pengeditan data barang!");
            }
            else if (!long.TryParse(input_jumlah_barang.Text, out a) || !long.TryParse(input_harga_satuan.Text, out a))
            {
                MessageBox.Show("Maaf, kolom jumlah barang dan harga satuan hanya boleh diisi dengan angka!");
            }
            else
            {
                long index = 0;
                SqlConnection conn = new SqlConnection(Settings.Default.conn);
                SqlCommand cmd = new SqlCommand($"SELECT * FROM tbl_barang WHERE id_barang='{input_id.Text}';", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    index++;
                }
                cmd.Dispose();
                reader.Close();
                conn.Close();
                if (index > 0)
                {
                    MessageBoxResult result = MessageBox.Show("Apakah anda yakin ingin mengubah data barang ini?", "Konfirmasi", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
                    if (result == MessageBoxResult.Yes)
                    {
                        string waktu = $"{input_expired_date.SelectedDate.Value.ToString().Split("/")[2].Split(" ")[0]}-{input_expired_date.SelectedDate.Value.ToString().Split("/")[1]}-{input_expired_date.SelectedDate.Value.ToString().Split("/")[0]}";
                        cmd = new SqlCommand($"UPDATE tbl_barang set kode_barang='{input_kode_barang.Text}', nama_barang='{input_nama_barang.Text}', expired_date='{waktu}', jumlah_barang={input_jumlah_barang.Text}, satuan='{input_satuan.Text.ToLower()}', harga_satuan={input_harga_satuan.Text} WHERE kode_barang='{input_kode_barang.Text}';", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        conn.Close();
                        RefreshDatagrid();
                        Reset();
                    }
                }
                else
                {
                    MessageBox.Show("Maaf, barang tidak terdaftar di database.");
                }
            }
        }

        private void DeleteBarang(object sender, RoutedEventArgs e)
        {
            long a = 0;
            if (input_id.Text == "")
            {
                MessageBox.Show("Maaf, anda belum memilih data dari database");
            }
            else if (input_kode_barang.Text == "" || input_nama_barang.Text == "" || input_expired_date.Text == "" || input_jumlah_barang.Text == "" || input_satuan.Text == "" || input_harga_satuan.Text == "")
            {
                MessageBox.Show("Maaf, semua kolom harus diisi untuk melanjutkan penghapusan data barang!");
            }
            else if (!long.TryParse(input_jumlah_barang.Text, out a) || !long.TryParse(input_harga_satuan.Text, out a))
            {
                MessageBox.Show("Maaf, kolom jumlah barang dan harga satuan hanya boleh diisi dengan angka!");
            }
            else
            {
                long index = 0;
                SqlConnection conn = new SqlConnection(Settings.Default.conn);
                SqlCommand cmd = new SqlCommand($"SELECT * FROM tbl_barang WHERE id_barang='{input_id.Text}';", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    index++;
                }
                cmd.Dispose();
                reader.Close();
                conn.Close();
                if (index > 0)
                {
                    MessageBoxResult result = MessageBox.Show("Apakah anda yakin ingin menghapus data barang ini?", "Konfirmasi", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
                    if (result == MessageBoxResult.Yes)
                    {
                        cmd = new SqlCommand($"DELETE FROM tbl_barang WHERE id_barang={input_id.Text};", conn);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        cmd.Dispose();
                        conn.Close();
                        RefreshDatagrid();
                        Reset();
                    }
                }
                else
                {
                    MessageBox.Show("Maaf, barang tidak terdaftar di database.");
                }
            }
        }

        private void TakeData(object sender, MouseButtonEventArgs e)
        {
            BarangModel data = datagrid.SelectedValue as BarangModel;
            if (data.satuan == "botol")
            {
                input_satuan.SelectedIndex = 0;
            }
            else if (data.satuan == "pcs")
            {
                input_satuan.SelectedIndex = 1;
            }
            input_kode_barang.Text = data.kode_barang;
            input_nama_barang.Text = data.nama_barang;
            input_expired_date.Text = data.expired_date;
            input_jumlah_barang.Text = data.jumlah_barang.ToString();
            input_harga_satuan.Text = data.harga_satuan.ToString();
            input_id.Text = data.id_barang;
        }

        void Reset()
        {
            input_kode_barang.Clear();
            input_nama_barang.Clear();
            input_expired_date.Text = "";
            input_jumlah_barang.Clear();
            input_satuan.SelectedIndex = 0;
            input_harga_satuan.Clear();
            input_id.Clear();
            input_kode_barang.Focus();
        }
    }
}
