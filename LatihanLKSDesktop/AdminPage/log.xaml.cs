using LatihanLKSDesktop.Properties;
using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static LatihanLKSDesktop.Model.BaseModel;

namespace LatihanLKSDesktop.AdminPage
{
    /// <summary>
    /// Interaction logic for log.xaml
    /// </summary>
    public partial class log : Page
    {
        public log()
        {
            InitializeComponent();
            date_fillter.SelectedDate = DateTime.Now;
            string now = $"{date_fillter.SelectedDate.Value.ToString().Split("/")[2].Split(" ")[0]}-{date_fillter.SelectedDate.Value.ToString().Split("/")[1]}-{date_fillter.SelectedDate.Value.ToString().Split("/")[0]} 00:00:00";
            string tomorow = $"{date_fillter.SelectedDate.Value.ToString().Split("/")[2].Split(" ")[0]}-{date_fillter.SelectedDate.Value.ToString().Split("/")[1]}-{date_fillter.SelectedDate.Value.AddDays(1).ToString().Split("/")[0]} 00:00:00";
            RefreshDatagrid(now, tomorow);
        }

        void RefreshDatagrid(string first, string last)
        {
            data_log.Items.Clear();
            SqlConnection conn = new SqlConnection(Settings.Default.conn);
            SqlCommand cmd = new SqlCommand($"SELECT tbl_log.id_log, tbl_log.waktu, tbl_log.aktivitas, tbl_user.username FROM tbl_log INNER JOIN tbl_user ON (tbl_log.id_user = tbl_user.id_user) WHERE (tbl_log.waktu BETWEEN '{first}' AND '{last}');", conn);
            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                LogModel data = new LogModel();
                data.id_log = reader.GetValue(0).ToString();
                data.waktu = reader.GetValue(1).ToString();
                data.aktivitas = reader.GetValue(2).ToString();
                data.username = reader.GetValue(3).ToString();
                data_log.Items.Add(data);
            }
            cmd.Dispose();
            reader.Close();
            conn.Close();
        }

        private void FillterDate(object sender, RoutedEventArgs e)
        {
            string now = $"{date_fillter.SelectedDate.Value.ToString().Split("/")[2].Split(" ")[0]}-{date_fillter.SelectedDate.Value.ToString().Split("/")[1]}-{date_fillter.SelectedDate.Value.ToString().Split("/")[0]} 00:00:00";
            string tomorow = $"{date_fillter.SelectedDate.Value.ToString().Split("/")[2].Split(" ")[0]}-{date_fillter.SelectedDate.Value.ToString().Split("/")[1]}-{date_fillter.SelectedDate.Value.AddDays(1).ToString().Split("/")[0]} 00:00:00";
            RefreshDatagrid(now, tomorow);
        }
    }
}
