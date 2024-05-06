using LatihanLKSDesktop.Properties;
using System;
using System.Collections.Generic;
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

namespace LatihanLKSDesktop
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
            AdminPage.log logPage = new AdminPage.log();
            MainContent.Content = logPage;
        }

        private void OpenUser(object sender, RoutedEventArgs e)
        {
            AdminPage.user userPage = new AdminPage.user();
            MainContent.Content = userPage;
        }

        private void OpenLaporan(object sender, RoutedEventArgs e)
        {
            AdminPage.laporan laporanPage = new AdminPage.laporan();
            MainContent.Content = laporanPage;
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            Settings.Default.credential = "";
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
