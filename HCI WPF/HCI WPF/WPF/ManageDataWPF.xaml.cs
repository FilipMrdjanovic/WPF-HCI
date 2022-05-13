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
    /// Interaction logic for ManageDataWPF.xaml
    /// </summary>
    public partial class ManageDataWPF : Window
    {
        public string pageName;
        public Object passedObject;

        public static readonly ManageDataWPF Instance = new ManageDataWPF();
        public ManageDataWPF()
        {
            InitializeComponent();


            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
        }

        public static void navigateToPage(string page)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(ManageDataWPF))
                {
                    (window as ManageDataWPF).Frame.Navigate(new Uri(string.Format("{0}{1}{2}", "Pages/", page, ".xaml"), UriKind.RelativeOrAbsolute));
                }
            }
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            navigateToPage(pageName);
        }
    }
}
