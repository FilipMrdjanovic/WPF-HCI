using HCI_WPF.Models;
using HCI_WPF.Services;
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
    /// Interaction logic for MedicinePage.xaml
    /// </summary>
    public partial class MedicinePage : Page
    {
        private int colNum = 0;
        public MedicineService medicineService = new MedicineService();
        public ObservableCollection<Medicine> medicine
        {
            get;
            set;
        }
        public MedicinePage()
        {
            InitializeComponent();
            this.DataContext = this;
            medicine = new ObservableCollection<Medicine>();

            foreach (Medicine m in medicineService.GetAll()) {
                medicine.Add(m);
            }

            btnEdit.IsEnabled = false;
            btnDelete.IsEnabled = false;

        }

        private void dgMedicine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnEdit.IsEnabled = true;
            btnDelete.IsEnabled = true;
        }
    }
}
