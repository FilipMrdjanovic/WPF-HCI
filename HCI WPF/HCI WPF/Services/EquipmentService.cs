using HCI_WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_WPF.Services
{
    public class EquipmentService
    {
        private Repository.EquipmentRepository equipmentRepository = new Repository.EquipmentRepository();
        public List<Equipment> GetAll()
        {
            return equipmentRepository.GetAll();
        }

        public Equipment GetById(int id)
        {
            return equipmentRepository.GetById(id);
        }

        public void Save(Equipment equipment)
        {
            equipmentRepository.Save(equipment);
        }

        public void Delete(int id)
        {
            equipmentRepository.Delete(id);
        }

        public void Update(Equipment equipment)
        {
            equipmentRepository.Update(equipment);
        }
    }
}
