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
    public class RenovationRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\renovations.json";
        private List<Renovation> allRenovation = new List<Renovation>();


        public RenovationRepository()
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
                    allRenovation = JsonConvert.DeserializeObject<List<Renovation>>(json);
                }
            }
        }
        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(allRenovation);
            File.WriteAllText(fileLocation, json);
        }

        public List<Renovation> GetAll()
        {
            ReadJson();
            return allRenovation;
        }

        public Renovation GetById(int id)
        {
            ReadJson();
            return allRenovation.Find(obj => obj.Id == id);
        }
        public void Save(Renovation renovation)
        {

            allRenovation.Add(renovation);
            WriteToJson();
        }

        public void Delete(int id)
        {
            ReadJson();
            int counter = 0;
            foreach (Renovation renovation in allRenovation)
            {
                if (renovation.Id == id)
                    break;
                else
                    counter++;
            }
            //int index = allRenovation.FindIndex(obj => obj.Id == id);
            allRenovation.RemoveAt(counter);
            WriteToJson();
        }
        public void Update(Renovation renovation)
        {
            ReadJson();
            Renovation passedRenovation = GetById(renovation.Id);
            passedRenovation.Description = renovation.Description;
            passedRenovation.TypeOfRenovation= renovation.TypeOfRenovation;

            WriteToJson();
        }
    }
}
