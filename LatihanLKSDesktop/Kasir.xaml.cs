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
    /// Interaction logic for Kasir.xaml
    /// </summary>
    public partial class Kasir : Window
    {
        public Kasir()
        {
            InitializeComponent();
            id_kasir.Text = Settings.Default.credential.Split(".")[3];
            input_harga_satuan.Text = "0";
            input_quantitas.Text = "1";
            input_total_harga.Text = "0";
            SqlConnection conn = new SqlConnection(Settings.Default.conn);
            SqlCommand cmd = new SqlCommand($"SELECT kode_barang, nama_barang FROM tbl_barang;", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                input_menu.Items.Add($"{reader.GetString(0).ToString()} - {reader.GetValue(1).ToString()}");
            }
            cmd.Dispose();
            reader.Close();
            conn.Close();
            input_menu.SelectedIndex = 0;
        }

        private void PilihMenu(object sender, SelectionChangedEventArgs e)
        {
            if (input_menu.SelectedIndex != 0)
            {
                SqlConnection conn = new SqlConnection(Settings.Default.conn);
                SqlCommand cmd = new SqlCommand($"SELECT harga_satuan FROM tbl_barang WHERE kode_barang='{input_menu.Text.Split(" - ")[0]}';", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    input_harga_satuan.Text = reader.GetValue(0).ToString();
                }
                cmd.Dispose();
                reader.Close();
                conn.Close();
            }
        }

        private void InputQuantitas(object sender, TextChangedEventArgs e)
        {
            long a;
            if (input_quantitas.Text.Length > 0 && long.TryParse(input_quantitas.Text, out a))
            {
                input_total_harga.Text = $"{long.Parse(input_harga_satuan.Text) * long.Parse(input_quantitas.Text)}";
            }else if (input_quantitas.Text.Length > 0 && !long.TryParse(input_quantitas.Text, out a))
            {
                MessageBox.Show("Maaf Kolom kuantitas hanya boleh berisi angka!");
                input_quantitas.Text = "0";
                input_total_harga.Text = $"{long.Parse(input_harga_satuan.Text) * long.Parse(input_quantitas.Text)}";
            }
            else
            {
                input_total_harga.Text = "0";
            }
        }

        private void InsertIntoKeranjang(object sender, RoutedEventArgs e)
        {
            if (input_menu.Text == "Kode - Nama Menu")
            {
                MessageBox.Show("Pilih terlebih dahulu menu!");
            }else
            {
                int index = 1;
                SqlConnection conn = new SqlConnection(Settings.Default.conn);
                SqlCommand cmd = new SqlCommand($"SELECT * FROM tbl_transaksi;", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    index++;
                }
                reader.Close();
                cmd.Dispose();
                conn.Close();
                KeranjangModel data = new KeranjangModel();
                data.id_transaksi = $"TR00{index}";
                data.kode_barang = input_menu.Text.Split(" - ")[0];
                data.nama_barang = input_menu.Text.Split(" - ")[1];
                data.harga_satuan = long.Parse(input_harga_satuan.Text);
                data.quantitas = long.Parse(input_quantitas.Text);
                data.subtotal = long.Parse(input_total_harga.Text);
                datagrid.Items.Add(data);
                total_harga.Content = $"{long.Parse(total_harga.Content.ToString()) + long.Parse(input_total_harga.Text)}";
            }
        }

        class KeranjangModel
        {
            public string id_transaksi {  get; set; }
            public string kode_barang {  get; set; }
            public string nama_barang { get; set; }
            public long harga_satuan { get; set; }
            public long quantitas {  get; set; }
            public long subtotal {  get; set; }
        }

        private void ResetDatagrid(object sender, RoutedEventArgs e)
        {
            datagrid.Items.Clear();
            total_harga.Content = "0";
        }

        private void InputHarga(object sender, TextChangedEventArgs e)
        {
            long a;
            if (input_harga_satuan.Text.Length > 0 && long.TryParse(input_quantitas.Text, out a))
            {
                input_total_harga.Text = $"{long.Parse(input_harga_satuan.Text) * long.Parse(input_quantitas.Text)}";
            }
            else
            {
                input_harga_satuan.Text = "0";
            }
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            Settings.Default.credential = "";
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void InputPembayaran(object sender, TextChangedEventArgs e)
        {
            long a;
            if (input_pembayaran.Text.Length > 0 && long.TryParse(input_pembayaran.Text, out a))
            {
                kembalian.Content = $"{long.Parse(total_harga.Content.ToString()) + long.Parse(input_pembayaran.Text)}";
            }else if (input_pembayaran.Text.Length > 0 && !long.TryParse(input_pembayaran.Text, out a))
            {
                MessageBox.Show("Maaf, kolom pembayaran harus berisi angka!");
                input_pembayaran.Text = "0";
            }else
            {
                kembalian.Content = "0";
            }
        }

        private void SaveTransaksi(object sender, RoutedEventArgs e)
        {
            if (long.Parse(kembalian.Content.ToString()) >= 0)
            {
                MessageBoxResult result = MessageBox.Show("Apakah anda yakin proses transaksi sudah sesuai?", "Konfirmasi", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes);
                if (result == MessageBoxResult.Yes)
                {
                    string waktu = $"{DateTime.Now.ToString().Split("/")[2].Split(" ")[0]}-{DateTime.Now.ToString().Split("/")[1]}-{DateTime.Now.ToString().Split("/")[0]} {DateTime.Now.ToString().Split("/")[2].Split(" ")[1]}";
                    foreach (KeranjangModel data in datagrid.Items)
                    {
                        SqlConnection conn = new SqlConnection(Settings.Default.conn);
                        SqlCommand cmd;
                        SqlDataReader reader;
                        conn.Open();
                        cmd = new SqlCommand($"SELECT id_barang FROM tbl_barang WHERE kode_barang='{data.kode_barang}'", conn);
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            cmd = new SqlCommand($"INSERT INTO tbl_transaksi(no_transaksi, tgl_transaksi, total_bayar, id_user, id_barang) VALUES('{data.id_transaksi}', '{waktu}', {data.subtotal}, {Settings.Default.credential.Split(".")[0]}, {reader.GetValue(0).ToString()});", conn);
                        }
                        cmd.ExecuteNonQuery();
                        reader.Close();
                        cmd.Dispose();
                        conn.Close();
                    }
                    MessageBox.Show("Data berhasil dicatat!");
                    input_pembayaran.Text = "";
                    datagrid.Items.Clear();
                    total_harga.Content = "0";
                }
            }
        }
    }
}
