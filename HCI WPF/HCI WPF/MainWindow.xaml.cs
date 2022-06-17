using HCI_WPF.Controllers;
using HCI_WPF.Models;
using HCI_WPF.WPF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace HCI_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UserController controller = new UserController();
        public bool firstTime { get; set; }

        public static readonly MainWindow Instance = new MainWindow();

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (firstTime)
            {
                var Help = new HelpWPF();
                Help.Show();
                firstTime = false;
            }
        }

        private void SignInButton(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(txtUsername.Text, @"^(?!\s*$).+") || !Regex.IsMatch(txtPassword.Password, @"^(?!\s*$).+"))
                MessageBox.Show("Please enter credentials", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
            else
            {
                User loggedUser = controller.Login(txtUsername.Text, txtPassword.Password);
                if (loggedUser != null)
                {
                    var MainPage = new MainPageWPF(loggedUser.Id, firstTime);
                    User.Instance.Id = loggedUser.Id;
                    MainPage.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Wrong credentials", "Login Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }


        }

        private void btnHelp_Click(object sender, RoutedEventArgs e)
        {
            var Help = new HelpWPF();
            Help.Show();    
        }
    }
}
