using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using LatihanLKSDesktop.Properties;
using static LatihanLKSDesktop.Controller.LogController;
using LatihanLKSDesktop.Controller;

namespace LatihanLKSDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            input_username.Focus();
        }

        private void Auth(object sender, RoutedEventArgs e)
        {
            if (input_username.Text == "" || input_password.Password == "")
            {
                MessageBox.Show("Maaf, semua kolom harus diisi untuk melanjutkan proses login!");
            }
            else
            {
                int index = 0;
                var username = input_username.Text;
                var password = input_password.Password;
                SqlConnection conn = new SqlConnection(Settings.Default.conn);
                SqlCommand cmd = new SqlCommand($"SELECT id_user,tipe_user,username,nama FROM tbl_user where username='{username}' AND password='{password}';", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    index++;
                    Settings.Default.credential = $"{reader.GetValue(0)}.{reader.GetValue(1)}.{reader.GetValue(2)}.{reader.GetValue(3)}";
                }
                if (index > 0)
                {
                    string tipe_user = Settings.Default.credential.Split(".")[1];
                    if (tipe_user == "admin")
                    {
                        logActivity("Login");
                        Admin window = new Admin();
                        window.Show();
                        Close();
                    }
                    else if (tipe_user == "gudang")
                    {
                        logActivity("Login");
                        Gudang window = new Gudang();
                        window.Show();
                        Close();
                    }
                    else if (tipe_user == "kasir")
                    {
                        logActivity("Login");
                        Kasir window = new Kasir();
                        window.Show();
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Maaf username atau password yang anda masukan salah!");
                }
                cmd.Dispose();
                reader.Close();
                conn.Close();
            }
        }

        private void Reset(object sender, RoutedEventArgs e)
        {
            input_username.Clear();
            input_password.Clear();
            input_username.Focus();
        }
    }
}