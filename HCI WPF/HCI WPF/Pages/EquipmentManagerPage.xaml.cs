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
    /// Interaction logic for EquipmentManagerPage.xaml
    /// </summary>
    public partial class EquipmentManagerPage : Page
    {
        EquipmentService equipmentService;
        RoomService roomService;
        public EquipmentManagerPage()
        {
            InitializeComponent();

            roomService = new RoomService();

            foreach (string roomName in roomService.FindAllTypesOfRoom())
            {
                cmbRoom.Items.Add(roomName);
            }


            if (MainPageWPF.ButtonEnabledInstance.createButton)
            {
                btnEdit.Visibility = Visibility.Hidden;
            }
            else
            {
                btnCreate.Visibility = Visibility.Hidden;
            }

            equipmentService = new EquipmentService();


            if (Equipment.Instance.Name != "")
                txtName.Text = Equipment.Instance.Name;

            if (Equipment.Instance.Quantity != null)
                txtQuantity.Text = Equipment.Instance.Quantity.ToString();

            if (Equipment.Instance.Location != "")
                cmbRoom.Text = Equipment.Instance.Location;


        }

        private void EditEquipment(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(txtName.Text, @"^(?!\s*$).+") || !Regex.IsMatch(txtQuantity.Text, @"^(?!\s*$).+") || !Regex.IsMatch(cmbRoom.Text, @"^(?!\s*$).+")) //Check Not Empty String 
            {
                MessageBox.Show("Fill all inputs!", "Inpur Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Equipment equipment = equipmentService.GetById(Equipment.Instance.Id);
                equipment.Name = txtName.Text;
                equipment.Quantity = Convert.ToInt32(txtQuantity.Text);
                equipment.Location = cmbRoom.Text;
                equipmentService.Update(equipment);

                MainPageWPF.navigateToPage("EquipmentPage");
                //((Window)Window.GetWindow(this)).Close();

            }
        }

        private void CreateEquipment(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(txtName.Text, @"^(?!\s*$).+") || !Regex.IsMatch(txtQuantity.Text, @"^(?!\s*$).+") || !Regex.IsMatch(cmbRoom.Text, @"^(?!\s*$).+")) //Check Not Empty String 
            {
                MessageBox.Show("Fill all inputs!", "Inpur Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var maxId = equipmentService.GetAll().Where(r => r != null)
                        .Select(r => r.Id)
                        .DefaultIfEmpty() // Now even if our where causes an empty selection list we will return DefaultIfEmpty.
                        .Max();

                Equipment equipment = new Equipment(maxId + 1, txtName.Text, Convert.ToInt32(txtQuantity.Text), cmbRoom.Text);
                equipmentService.Save(equipment);

                MainPageWPF.navigateToPage("EquipmentPage");
                //((Window)Window.GetWindow(this)).Close();
            }
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            MainPageWPF.navigateToPage("EquipmentPage");
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtName.Text == null || cmbRoom.Text == null)
                btnEdit.IsEnabled = btnCreate.IsEnabled = false;
            else
                btnEdit.IsEnabled = btnCreate.IsEnabled = true;
        }

        private void cmbRoom_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtName.Text == null || cmbRoom.Text == null)
                btnEdit.IsEnabled = btnCreate.IsEnabled = false;
            else
                btnEdit.IsEnabled = btnCreate.IsEnabled = true;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
