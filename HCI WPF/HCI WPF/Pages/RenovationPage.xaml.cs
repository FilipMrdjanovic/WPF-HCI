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
    /// Interaction logic for RenovationPage.xaml
    /// </summary>
    public partial class RenovationPage : Page
    {
        public RenovationService renovationService;
        public Renovation selectedRenovationItem;

        public static readonly RenovationPage Instance = new RenovationPage();

        public bool refresh { get; set; }

        public ObservableCollection<Renovation> renovation
        {
            get;
            set;
        }
        public RenovationPage()
        {
            InitializeComponent();

            refresh = false;
            this.DataContext = this;
            renovation = new ObservableCollection<Renovation>();

            //btnEdit.IsEnabled = false;
            //btnDelete.IsEnabled = false; 
        }

        private void dgRenovation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //btnEdit.IsEnabled = true;
            //btnDelete.IsEnabled = true;
            //btnCreate.IsEnabled = false;
            selectedRenovationItem = (Renovation)dgRenovation.SelectedItem;
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (dgRenovation.SelectedItem != null)
            {
                //ManageDataWPF DataManager = new ManageDataWPF();

                //DataManager.pageName = "RenovationManagerPage";
                //DataManager.Title = "Renovation Manager Page";


                Renovation.Instance.Id = selectedRenovationItem.Id;
                Renovation.Instance.Description = selectedRenovationItem.Description;
                Renovation.Instance.TypeOfRenovation= selectedRenovationItem.TypeOfRenovation;


                MainPageWPF.navigateToPage("RenovationManagerPage");
                //DataManager.Show();
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {


            MainPageWPF.navigateToPage("RenovationManagerPage");

            // ManageDataWPF DataManager = new ManageDataWPF();

            //DataManager.pageName = "RenovationManagerPage";
            //DataManager.Title = "Renovation Manager Page";

            Renovation.Instance.Id = -1;
            Renovation.Instance.Description = "";
            Renovation.Instance.TypeOfRenovation = "Basic";

            //DataManager.Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (dgRenovation.SelectedItem != null)
            {
                if (MessageBox.Show("Delete renovation with data:\nDescription: " + selectedRenovationItem.Description + "\nTypeOfRenovation: " + selectedRenovationItem.TypeOfRenovation, "Delete Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    renovationService.Delete(selectedRenovationItem.Id);
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
            renovation.Clear();
            renovationService = new RenovationService();
            foreach (Renovation m in renovationService.GetAll())
            {
                renovation.Add(m);
            }
        }
    }
}
