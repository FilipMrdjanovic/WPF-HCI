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
    /// Interaction logic for MedicinePage.xaml
    /// </summary>
    public partial class MedicinePage : Page
    {
        public MedicineService medicineService;
        public Medicine selectedMedicineItem;

        public static readonly MedicinePage Instance = new MedicinePage();

        public bool refresh { get; set; }

        public ObservableCollection<Medicine> medicine
        {
            get;
            set;
        }
        public MedicinePage()
        {
            InitializeComponent();

            refresh = false;
            this.DataContext = this;
            medicine = new ObservableCollection<Medicine>();

            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false; 
        }

        private void dgMedicine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnEdit.IsEnabled = true;
            btnDelete.IsEnabled = true;
            btnCreate.IsEnabled = false;
            selectedMedicineItem = (Medicine)dgMedicine.SelectedItem;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if(dgMedicine.SelectedItem != null)
            {
                ManageDataWPF DataManager = new ManageDataWPF();

                DataManager.pageName = "MedicineManagerPage";
                DataManager.Title = "Medicine Manager Page";


                Medicine.Instance.Id = selectedMedicineItem.Id;
                Medicine.Instance.Name = selectedMedicineItem.Name;
                Medicine.Instance.Quantity = selectedMedicineItem.Quantity;

                DataManager.Show();
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
          
            ManageDataWPF DataManager = new ManageDataWPF();

            DataManager.pageName = "MedicineManagerPage";
            DataManager.Title = "Medicine Manager Page";

            Medicine.Instance.Id = -1;
            Medicine.Instance.Name = "";
            Medicine.Instance.Quantity = 0;

            DataManager.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgMedicine.SelectedItem != null)
            {
                if (MessageBox.Show("Delete medicine with data:\nName: " + selectedMedicineItem.Name + "\nQuantity: " + selectedMedicineItem.Quantity, "Login Error", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    medicineService.Delete(selectedMedicineItem.Id);
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
            medicine.Clear();
            medicineService = new MedicineService();
            foreach (Medicine m in medicineService.GetAll())
            {
                medicine.Add(m);
            }
        }
    }
}
