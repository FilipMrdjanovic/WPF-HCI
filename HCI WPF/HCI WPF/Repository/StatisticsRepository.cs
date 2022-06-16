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
    public class StatisticsRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\statistics.json";
        private List<Statistics> allStatistics = new List<Statistics>();


        public StatisticsRepository()
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
                    allStatistics = JsonConvert.DeserializeObject<List<Statistics>>(json);
                }
            }
        }
        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(allStatistics);
            File.WriteAllText(fileLocation, json);
        }

        public List<Statistics> GetAll()
        {
            ReadJson();
            return allStatistics;
        }

        public Statistics GetById(int id)
        {
            ReadJson();
            return allStatistics.Find(obj => obj.Id == id);
        }
        public void Save(Statistics statistics)
        {

            allStatistics.Add(statistics);
            WriteToJson();
        }

        public void Delete(int id)
        {
            ReadJson();
            int counter = 0;
            foreach (Statistics statistics in allStatistics)
            {
                if (statistics.Id == id)
                    break;
                else
                    counter++;
            }
            //int index = allStatistics.FindIndex(obj => obj.Id == id);
            allStatistics.RemoveAt(counter);
            WriteToJson();
        }
        public void Update(Statistics statistics)
        {
            ReadJson();
            Statistics passedStatistics = GetById(statistics.Id);
            passedStatistics.Description = statistics.Description;
            passedStatistics.Stars = statistics.Stars;
            passedStatistics.Overall = statistics.Overall;

            WriteToJson();
        }
    }
}
