using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HCI_WPF.Models;
using Newtonsoft.Json;

namespace HCI_WPF.Repository
{
    public class UserRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\users.json";
        private List<User> users = new List<User>();


        public UserRepository()
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
                    users = JsonConvert.DeserializeObject<List<User>>(json);
                }
            }
        }
        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(users);
            File.WriteAllText(fileLocation, json);
        }

        public List<User> GetAll()
        {
            ReadJson();
            return users;
        }

        public User GetById(int id)
        {
            ReadJson();
            return users.Find(obj => obj.Id == id);
        }
        public void Save(User user)
        {

            users.Add(user);
            WriteToJson();
        }

        public void Delete(int id)
        {
            ReadJson();
            int index = users.FindIndex(obj => obj.Id == id);
            users.RemoveAt(index);
            WriteToJson();
        }
    }
}
