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
    public class MedicineRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\medicine.json";
        private List<Medicine> allMedicine = new List<Medicine>();


        public MedicineRepository()
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
                    allMedicine = JsonConvert.DeserializeObject<List<Medicine>>(json);
                }
            }
        }
        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(allMedicine);
            File.WriteAllText(fileLocation, json);
        }

        public List<Medicine> GetAll()
        {
            ReadJson();
            return allMedicine;
        }

        public Medicine GetById(int id)
        {
            ReadJson();
            return allMedicine.Find(obj => obj.Id == id);
        }
        public void Save(Medicine medicine)
        {

            allMedicine.Add(medicine);
            WriteToJson();
        }

        public void Delete(int id)
        {
            ReadJson();
            int index = allMedicine.FindIndex(obj => obj.Id == id);
            allMedicine.RemoveAt(index);
            WriteToJson();
        }
    }
}
