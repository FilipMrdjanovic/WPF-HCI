using HCI_WPF.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_WPF.Repository
{
public class EquipmentRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\equipment.json";
        private List<Equipment> allEquipment = new List<Equipment>();


        public EquipmentRepository()
        {
            ReadJson();
        }

        public void ReadJson()
        {
            if (!File.Exists(fileLocation))
            {
                File.Create(fileLocation).Close();
            }

            using (StreamReader r = new StreamReader(fileLocation))
            {
                string json = r.ReadToEnd();
                if (json != "")
                {
                    allEquipment = JsonConvert.DeserializeObject<List<Equipment>>(json);
                }
            }
        }
        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(allEquipment);
            File.WriteAllText(fileLocation, json);
        }

        public List<Equipment> GetAll()
        {
            ReadJson();
            return allEquipment;
        }

        public Equipment GetById(int id)
        {
            ReadJson();
            return allEquipment.Find(obj => obj.Id == id);
        }
        public void Save(Equipment equipment)
        {

            allEquipment.Add(equipment);
            WriteToJson();
        }

        public void Delete(int id)
        {
            ReadJson();
            int counter = 0;
            foreach(Equipment equipment in allEquipment)
            {
                if (equipment.Id == id)
                    break;
                else
                    counter++;
            }
            //int index = allEquipment.FindIndex(obj => obj.Id == id);
            allEquipment.RemoveAt(counter);
            WriteToJson();
        }
        public void Update(Equipment equipment)
        {
            ReadJson();
            Equipment passedEquipment = GetById(equipment.Id);
            passedEquipment.Name = equipment.Name;
            passedEquipment.Quantity = equipment.Quantity;
            passedEquipment.Location = equipment.Location;

            WriteToJson();
        }
    }
}
