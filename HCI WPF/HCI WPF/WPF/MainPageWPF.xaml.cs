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
    /// 

    public class ButtonEnabled
    {
        public bool enableButton { get; set; }
        public bool createButton { get; set; }

        public ButtonEnabled()
        {
        }

        public ButtonEnabled(bool enableButton, bool createButton)
        {
            this.enableButton = enableButton;
            this.createButton = createButton;
        }

        public static readonly ButtonEnabled Instance = new ButtonEnabled();

    }

    public partial class MainPageWPF : Window
    {
        public static readonly ButtonEnabled ButtonEnabledInstance = new ButtonEnabled();
        public static readonly MainPageWPF Instance = new MainPageWPF(User.Instance.Id, false);

        public MainPageWPF(int id, bool firstTime)
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

        private void btnEquipment_Click(object sender, RoutedEventArgs e)
        {
            navigateToPage("EquipmentPage");
        }

        private void btnStatistics_Click(object sender, RoutedEventArgs e)
        {
            navigateToPage("StatisticsPage");
        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            var Help = new HelpWPF();
            Help.Show();
        }
    }
}
