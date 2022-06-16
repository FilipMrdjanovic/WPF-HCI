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
using System.Windows.Threading;

namespace HCI_WPF.Pages
{
    /// <summary>
    /// Interaction logic for EquipmentPage.xaml
    /// </summary>
    public partial class EquipmentPage : Page
    {
        public EquipmentService equipmentService;
        public Equipment selectedEquipmentItem;

        public static readonly EquipmentPage Instance = new EquipmentPage();

        public bool refresh { get; set; }

        public ObservableCollection<Equipment> equipment
        {
            get;
            set;
        }
        public EquipmentPage()
        {
            InitializeComponent();

            refresh = false;
            this.DataContext = this;
            equipment = new ObservableCollection<Equipment>();

            //btnEdit.IsEnabled = false;
            //btnDelete.IsEnabled = false; 
        }

        private void dgEquipment_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //btnEdit.IsEnabled = true;
            //btnDelete.IsEnabled = true;
            //btnCreate.IsEnabled = false;
            selectedEquipmentItem = (Equipment)dgEquipment.SelectedItem;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgEquipment.SelectedItem != null)
            {

                MainPageWPF.ButtonEnabledInstance.enableButton = true;
                //ManageDataWPF DataManager = new ManageDataWPF();

                //DataManager.pageName = "EquipmentManagerPage";
                //DataManager.Title = "Equipment Manager Page";


                Equipment.Instance.Id = selectedEquipmentItem.Id;
                Equipment.Instance.Name = selectedEquipmentItem.Name;
                Equipment.Instance.Quantity = selectedEquipmentItem.Quantity;
                Equipment.Instance.Location = selectedEquipmentItem.Location;


                MainPageWPF.navigateToPage("EquipmentManagerPage");
                //DataManager.Show();
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {


            MainPageWPF.ButtonEnabledInstance.createButton = true;


            MainPageWPF.navigateToPage("EquipmentManagerPage");

            // ManageDataWPF DataManager = new ManageDataWPF();

            //DataManager.pageName = "EquipmentManagerPage";
            //DataManager.Title = "Equipment Manager Page";

            Equipment.Instance.Id = -1;
            Equipment.Instance.Name = "";
            Equipment.Instance.Quantity = 1;
            Equipment.Instance.Location = "";

            //DataManager.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgEquipment.SelectedItem != null)
            {
                if (MessageBox.Show("Delete equipment with data:\nName: " + selectedEquipmentItem.Name + "\nQuantity: " + selectedEquipmentItem.Quantity + "\nLocation: " + selectedEquipmentItem.Location, "Delete Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    equipmentService.Delete(selectedEquipmentItem.Id);
                    RefreshPage();
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            App.ActivatedPage = this;
            RefreshPage();
            MainPageWPF.ButtonEnabledInstance.enableButton = false;
            MainPageWPF.ButtonEnabledInstance.createButton = false;
        }

        public void RefreshPage()
        {
            equipment.Clear();
            equipmentService = new EquipmentService();
            foreach (Equipment m in equipmentService.GetAll())
            {
                equipment.Add(m);
            }
        }
    }
}
