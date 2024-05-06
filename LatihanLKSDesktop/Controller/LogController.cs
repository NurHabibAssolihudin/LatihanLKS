using LatihanLKSDesktop.Properties;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LatihanLKSDesktop.Controller
{
    internal class LogController
    {
        public static void logActivity(string aktivitas)
        {
            string id_user = Settings.Default.credential.Split('.')[0];
            string waktu = $"{DateTime.Now.ToString().Split("/")[2].Split(" ")[0]}-{DateTime.Now.ToString().Split("/")[1]}-{DateTime.Now.ToString().Split("/")[0]} {DateTime.Now.ToString().Split("/")[2].Split(" ")[1]}";
            SqlConnection conn = new SqlConnection(Settings.Default.conn);
            SqlCommand cmd = new SqlCommand($"INSERT INTO tbl_log(id_user, aktivitas, waktu) VALUES({id_user}, '{aktivitas}', '{waktu}');", conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
        }
    }
}
