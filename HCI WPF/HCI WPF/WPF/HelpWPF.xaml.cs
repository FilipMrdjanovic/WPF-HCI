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
    /// Interaction logic for HelpWPF.xaml
    /// </summary>
    public partial class HelpWPF : Window
    {
        int i = 1;
        List<string> list;
        public HelpWPF()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            list = new List<string>();

            list.Add("In this window, user is supposed to enter personal credentials such as username and password");
            list.Add("In this window, user is supposed to pick correspoding menu by clicking on one of icons in the bottom menu. User can also log out of the app by clicking on Top Right icon");
            list.Add("In this window, user can edit, create and delete data for the corresponfing menu");
            list.Add("In this window, user is able to insert data to change selected element from the list");
            list.Add("In this window, user is required to insert data to be able to create new data element");
            list.Add("In this window, user is informed that the selected element is about to be deleted and is given a choice to continue with deleting or abort");
            list.Add("In this window, user is able to see aquired statistics from users rating the app");
            lblDescription.Text = list[0];
        }
        

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            i++;
            if (i > 7)
                i = 7;
            HelpImage.Source = new BitmapImage(new Uri("../Resources/Help Images/" + i + ".png", UriKind.Relative));
            lblDescription.Text = list[i-1].ToString();
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            i--;
            if (i < 1)
                i = 1;
            HelpImage.Source = new BitmapImage(new Uri("../Resources/Help Images/" + i+".png",UriKind.Relative));
            lblDescription.Text = list[i-1].ToString();
        }
    }
}
