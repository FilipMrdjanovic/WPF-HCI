using HCI_WPF.Models;
using HCI_WPF.Services;
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

namespace HCI_WPF.Pages
{
    /// <summary>
    /// Interaction logic for RenovationManagerPage.xaml
    /// </summary>
    public partial class RenovationManagerPage : Page
    {
        RenovationService renovationService;
        public RenovationManagerPage()
        {
            InitializeComponent();

            renovationService = new RenovationService();

            if (txtDescription.Text == null || txtType.Text == null)
            {
                btnEdit.IsEnabled = btnCreate.IsEnabled = false;
            }
            if (Renovation.Instance.Description != "")
                txtDescription.Text = Renovation.Instance.Description;

            txtType.Text = Renovation.Instance.TypeOfRenovation.ToString();

            if (Renovation.Instance.Id == -1)
            {
                btnEdit.IsEnabled = false;
            }
        }

        private void EditRenovation(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(txtDescription.Text, @"^(?!\s*$).+") || !Regex.IsMatch(txtType.Text, @"^(?!\s*$).+")) //Check Not Empty String 
            {
                MessageBox.Show("Fill all inputs!", "Inpur Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Renovation renovation = renovationService.GetById(Renovation.Instance.Id);
                renovation.Description = txtDescription.Text;
                renovation.TypeOfRenovation = txtType.Text;
                renovationService.Update(renovation);

                MainPageWPF.navigateToPage("RenovationPage");
                //((Window)Window.GetWindow(this)).Close();

            }
        }

        private void CreateRenovation(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(txtDescription.Text, @"^(?!\s*$).+") || !Regex.IsMatch(txtType.Text, @"^(?!\s*$).+")) //Check Not Empty String 
            {
                MessageBox.Show("Fill all inputs!", "Inpur Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var maxId = renovationService.GetAll().Where(r => r != null)
                        .Select(r => r.Id)
                        .DefaultIfEmpty() // Now even if our where causes an empty selection list we will return DefaultIfEmpty.
                        .Max();

                Renovation renovation = new Renovation(maxId + 1, txtDescription.Text, txtType.Text);
                renovationService.Save(renovation);

                MainPageWPF.navigateToPage("RenovationPage");
                //((Window)Window.GetWindow(this)).Close();
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainPageWPF.navigateToPage("RenovationPage");
        }

        private void txtDescription_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtDescription.Text == null || txtType.Text == null)
                btnEdit.IsEnabled = btnCreate.IsEnabled = false;
            else
                btnEdit.IsEnabled = btnCreate.IsEnabled = true;
        }

        private void txtType_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtDescription.Text == null || txtType.Text == null)
                btnEdit.IsEnabled = btnCreate.IsEnabled = false;
            else
                btnEdit.IsEnabled = btnCreate.IsEnabled = true;
        }
    }
}
