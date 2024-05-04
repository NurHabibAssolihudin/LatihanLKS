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
    /// Interaction logic for laporan.xaml
    /// </summary>
    public partial class laporan : Page
    {
        public laporan()
        {
            InitializeComponent();
            first_date.SelectedDate = DateTime.Now;
            last_date.SelectedDate = DateTime.Now.AddDays(1);
            string now = $"{first_date.SelectedDate.Value.ToString().Split("/")[2].Split(" ")[0]}-{first_date.SelectedDate.Value.ToString().Split("/")[1]}-{first_date.SelectedDate.Value.ToString().Split("/")[0]}";
            string tomorow = $"{last_date.SelectedDate.Value.ToString().Split("/")[2].Split(" ")[0]}-{last_date.SelectedDate.Value.ToString().Split("/")[1]}-{last_date.SelectedDate.Value.ToString().Split("/")[0]}";
            RefreshDatagrid(now, tomorow);
        }

        void RefreshDatagrid(string first, string last)
        {
            datagrid.Items.Clear();
            SqlConnection conn = new SqlConnection(Settings.Default.conn);
            SqlCommand cmd = new SqlCommand($"SELECT tbl_transaksi.no_transaksi, tbl_transaksi.tgl_transaksi, tbl_transaksi.total_bayar, tbl_user.nama FROM tbl_transaksi INNER JOIN tbl_user ON (tbl_transaksi.id_user = tbl_user.id_user) WHERE (tbl_transaksi.tgl_transaksi BETWEEN '{first}' AND '{last}');", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                TransaksiModel data = new TransaksiModel();
                data.no_transaksi = reader.GetValue(0).ToString();
                data.tgl_transaksi = reader.GetValue(1).ToString();
                data.total_bayar = long.Parse(reader.GetValue(2).ToString());
                data.id_user = reader.GetValue(3).ToString();
                datagrid.Items.Add(data);
            }
            cmd.Dispose();
            reader.Close();
            conn.Close();
        }

        private void TransactionFillter(object sender, RoutedEventArgs e)
        {
            string now = $"{first_date.SelectedDate.Value.ToString().Split("/")[2].Split(" ")[0]}-{first_date.SelectedDate.Value.ToString().Split("/")[1]}-{first_date.SelectedDate.Value.ToString().Split("/")[0]}";
            string tomorow = $"{last_date.SelectedDate.Value.ToString().Split("/")[2].Split(" ")[0]}-{last_date.SelectedDate.Value.ToString().Split("/")[1]}-{last_date.SelectedDate.Value.ToString().Split("/")[0]}";
            RefreshDatagrid(now, tomorow);
        }
    }
}
