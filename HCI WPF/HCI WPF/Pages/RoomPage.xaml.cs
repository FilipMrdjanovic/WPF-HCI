using HCI_WPF.Models;
using HCI_WPF.Services;
using HCI_WPF.WPF;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HCI_WPF.Pages
{
    /// <summary>
    /// Interaction logic for RoomPage.xaml
    /// </summary>
    public partial class RoomPage : Page
    {
        public RoomService roomService;
        public Room selectedRoomItem;

        public static readonly RoomPage Instance = new RoomPage();

        public bool refresh { get; set; }

        public ObservableCollection<Room> rooms
        {
            get;
            set;
        }
        public RoomPage()
        {
            InitializeComponent();

            refresh = false;
            this.DataContext = this;
            rooms = new ObservableCollection<Room>();

            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false;
        }

        private void dgRooms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnEdit.IsEnabled = true;
            btnDelete.IsEnabled = true;
            btnCreate.IsEnabled = false;
            selectedRoomItem = (Room)dgRooms.SelectedItem;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgRooms.SelectedItem != null)
            {
                //ManageDataWPF DataManager = new ManageDataWPF();

                //DataManager.pageName = "RoomManagerPage";
                //DataManager.Title = "Room Manager Page";


                Room.Instance.Id = selectedRoomItem.Id;
                Room.Instance.Name = selectedRoomItem.Name;
                Room.Instance.Floor = selectedRoomItem.Floor;

                MainPageWPF.navigateToPage("RoomManagerPage");

                //DataManager.Show();
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {

            //ManageDataWPF DataManager = new ManageDataWPF();

            //DataManager.pageName = "RoomManagerPage";
            //DataManager.Title = "Room Manager Page";

            Room.Instance.Id = -1;
            Room.Instance.Name = "";
            Room.Instance.Floor = 0;

            MainPageWPF.navigateToPage("RoomManagerPage");
            //DataManager.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgRooms.SelectedItem != null)
            {
                if (MessageBox.Show("Delete room with data:\nName: " + selectedRoomItem.Name + "\nFloor: " + selectedRoomItem.Floor, "Login Error", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    roomService.Delete(selectedRoomItem.Id);
                    RefreshPage();
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.ActivatedPage = this;
            RefreshPage();
        }

        public void RefreshPage()
        {
            rooms.Clear();
            roomService = new RoomService();
            foreach (Room m in roomService.GetAll())
            {
                rooms.Add(m);
            }
        }
       
    }
}
