using HCI_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_WPF.Services
{
    public class RenovationService
    {
        private Repository.RenovationRepository renovationRepository = new Repository.RenovationRepository();
        public List<Renovation> GetAll()
        {
            return renovationRepository.GetAll();
        }

        public Renovation GetById(int id)
        {
            return renovationRepository.GetById(id);
        }

        public void Save(Renovation renovation)
        {
            renovationRepository.Save(renovation);
        }

        public void Delete(int id)
        {
            renovationRepository.Delete(id);
        }

        public void Update(Renovation renovation)
        {
            renovationRepository.Update(renovation);
        }
    }
}
