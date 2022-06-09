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
    /// Interaction logic for RoomManagerPage.xaml
    /// </summary>
    public partial class RoomManagerPage : Page
    {
        RoomService roomService;
        public RoomManagerPage()
        {
            InitializeComponent();

            roomService = new RoomService();

            if (txtName.Text == null || txtFloor.Text == null)
            {
                btnEdit.IsEnabled = btnCreate.IsEnabled = false;
            }
            if (Room.Instance.Name != "")
                txtName.Text = Room.Instance.Name;

            txtFloor.Text = Room.Instance.Floor.ToString();

            if (Room.Instance.Id == -1)
            {
                btnEdit.IsEnabled = false;
            }
        }

        private void EditRoom(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(txtName.Text, @"^(?!\s*$).+") || !Regex.IsMatch(txtFloor.Text, @"^(?!\s*$).+")) //Check Not Empty String 
            {
                MessageBox.Show("Fill all inputs!", "Inpur Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                Room room = roomService.GetById(Room.Instance.Id);
                room.Name = txtName.Text;
                room.Floor = Convert.ToInt32(txtFloor.Text);
                roomService.Update(room);

                MainPageWPF.navigateToPage("RoomPage");
                //((Window)Window.GetWindow(this)).Close();

            }
        }

        private void CreateRoom(object sender, RoutedEventArgs e)
        {
            if (!Regex.IsMatch(txtName.Text, @"^(?!\s*$).+") || !Regex.IsMatch(txtFloor.Text, @"^(?!\s*$).+")) //Check Not Empty String 
            {
                MessageBox.Show("Fill all inputs!", "Inpur Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                var maxId = roomService.GetAll().Where(r => r != null)
                        .Select(r => r.Id)
                        .DefaultIfEmpty() // Now even if our where causes an empty selection list we will return DefaultIfEmpty.
                        .Max();

                Room room = new Room(maxId + 1, txtName.Text, Convert.ToInt32(txtFloor.Text));
                roomService.Save(room);

                MainPageWPF.navigateToPage("RoomPage");
                //((Window)Window.GetWindow(this)).Close();
            }
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtName.Text == null || txtFloor.Text == null)
                btnEdit.IsEnabled = btnCreate.IsEnabled = false;
            else
                btnEdit.IsEnabled = btnCreate.IsEnabled = true;
        }

        private void txtFloor_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtName.Text == null || txtFloor.Text == null)
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

