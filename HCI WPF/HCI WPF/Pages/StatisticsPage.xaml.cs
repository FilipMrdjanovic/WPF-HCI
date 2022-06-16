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
    /// Interaction logic for StatisticsPage.xaml
    /// </summary>
    public partial class StatisticsPage : Page
    {
        public StatisticsService statisticsService;
        public Statistics selectedStatisticsItem;

        public static readonly StatisticsPage Instance = new StatisticsPage();

        public bool refresh { get; set; }

        public StatisticsPage()
        {
            InitializeComponent();

            StatisticsService statisticsService = new StatisticsService();

            List<Statistics> statisticsList = statisticsService.GetAll();

            double stats = 0;
            double overall = 0;
            foreach (Statistics statistics in statisticsList)
            {
                stats += statistics.Stars;
                overall += statistics.Overall;
            }

            lblStats.Content = "Stars: " + stats / statisticsList.Count + " / 5";

            switch (overall / statisticsList.Count)
            {
                case double n when n >= 4:
                    lblOverall.Content = "Overall: EXCELENT";
                    break;

                case double n when n >= 3:
                    lblOverall.Content = "Overall: GOOD";
                    break;

                case double n when n >= 2:
                    lblOverall.Content = "Overall: POOR";
                    break;

                default:
                    lblOverall.Content = "Overall: BAD";
                    break;
            }


            refresh = false;
            this.DataContext = this;


            foreach (Statistics m in statisticsService.GetAll())
            {
                lbStatistics.Items.Add(m.Description);
            }

        }
    }

}
