using HCI_WPF.Models;
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

namespace HCI_WPF.WPF
{
    /// <summary>
    /// Interaction logic for MainPageWPF.xaml
    /// </summary>
    public partial class MainPageWPF : Window
    {
        public static readonly MainPageWPF Instance = new MainPageWPF(User.Instance.Id);
        public MainPageWPF(int id)
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        public static void navigateToPage(string page)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainPageWPF))
                {
                    (window as MainPageWPF).Frame.Navigate(new Uri(string.Format("{0}{1}{2}", "Pages/", page, ".xaml"), UriKind.RelativeOrAbsolute));
                }
            }
        }

        private void btnMedicine_Click(object sender, RoutedEventArgs e)
        {
            navigateToPage("MedicinePage");
        }

        private void btnRoom_Click(object sender, RoutedEventArgs e)
        {
            navigateToPage("RoomPage");
        }
        private void btnRenovation_Click(object sender, RoutedEventArgs e)
        {

            navigateToPage("RenovationPage");
        }
        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            var LoginPage = new MainWindow();
            LoginPage.Show();
            this.Close();
        }

    }
}
