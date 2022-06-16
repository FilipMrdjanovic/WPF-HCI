using HCI_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_WPF.Services
{
    public class StatisticsService
    {
        private Repository.StatisticsRepository statisticsRepository = new Repository.StatisticsRepository();
        public List<Statistics> GetAll()
        {
            return statisticsRepository.GetAll();
        }

        public Statistics GetById(int id)
        {
            return statisticsRepository.GetById(id);
        }

        public void Save(Statistics statistics)
        {
            statisticsRepository.Save(statistics);
        }

        public void Delete(int id)
        {
            statisticsRepository.Delete(id);
        }

        public void Update(Statistics statistics)
        {
            statisticsRepository.Update(statistics);
        }
    }
}
