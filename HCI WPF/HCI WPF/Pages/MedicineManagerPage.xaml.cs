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
    /// Interaction logic for MedicineManagerPage.xaml
    /// </summary>
    public partial class MedicineManagerPage : Page
    {
        MedicineService medicineService;
        public MedicineManagerPage()
        {
            InitializeComponent();

            if (MainPageWPF.ButtonEnabledInstance.createButton)
            {
                btnEdit.Visibility = Visibility.Hidden;
            }
            else
            {
                btnCreate.Visibility = Visibility.Hidden;
            }
            medicineService = new MedicineService();

            if (txtName.Text == null || txtQuantity.Text == null)
            {
                btnEdit.IsEnabled = btnCreate.IsEnabled = false;
            }
            if (Medicine.Instance.Name != "")
                txtName.Text = Medicine.Instance.Name;

            txtQuantity.Text = Medicine.Instance.Quantity.ToString();

            if (Medicine.Instance.Id == -1)
            {
                btnEdit.IsEnabled = false;
            }
        }

        private void EditMedicine(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(txtName.Text, @"^(?!\s*$).+") || !Regex.IsMatch(txtQuantity.Text, @"^(?!\s*$).+")) //Check Not Empty String 
            {
                MessageBox.Show("Fill all inputs!", "Inpur Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Medicine medicine = medicineService.GetById(Medicine.Instance.Id);
                medicine.Name = txtName.Text;
                medicine.Quantity = Convert.ToInt32(txtQuantity.Text);
                medicineService.Update(medicine);

                MainPageWPF.navigateToPage("MedicinePage");
                //((Window)Window.GetWindow(this)).Close();

            }
        }

        private void CreateMedicine(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(txtName.Text, @"^(?!\s*$).+") || !Regex.IsMatch(txtQuantity.Text, @"^(?!\s*$).+")) //Check Not Empty String 
            {
                MessageBox.Show("Fill all inputs!", "Inpur Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var maxId = medicineService.GetAll().Where(r => r != null)
                        .Select(r => r.Id)
                        .DefaultIfEmpty() // Now even if our where causes an empty selection list we will return DefaultIfEmpty.
                        .Max();

                Medicine medicine = new Medicine(maxId + 1, txtName.Text, Convert.ToInt32(txtQuantity.Text));
                medicineService.Save(medicine);

                MainPageWPF.navigateToPage("MedicinePage");
                //((Window)Window.GetWindow(this)).Close();
            }
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtName.Text == null || txtQuantity.Text == null)
                btnEdit.IsEnabled = btnCreate.IsEnabled = false;
            else
                btnEdit.IsEnabled = btnCreate.IsEnabled = true;
        }

        private void txtQuantity_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtName.Text == null || txtQuantity.Text == null)
                btnEdit.IsEnabled = btnCreate.IsEnabled = false;
            else
                btnEdit.IsEnabled = btnCreate.IsEnabled = true;
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainPageWPF.navigateToPage("MedicinePage");
        }
    }
}
