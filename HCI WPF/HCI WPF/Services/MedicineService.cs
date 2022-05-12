using HCI_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_WPF.Services
{
    public class MedicineService
    {
        private Repository.MedicineRepository medicineRepository = new Repository.MedicineRepository();
        public List<Medicine> GetAll()
        {
            return medicineRepository.GetAll();
        }

        public Medicine GetById(int id)
        {
            return medicineRepository.GetById(id);
        }

        public void Save(Medicine medicine)
        {
            medicineRepository.Save(medicine);
        }

        public void Delete(int id)
        {
            medicineRepository.Delete(id);
        }
    }
}
