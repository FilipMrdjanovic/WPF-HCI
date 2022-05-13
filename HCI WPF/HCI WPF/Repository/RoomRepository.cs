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
    public class RoomRepository
    {
        private readonly string fileLocation = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\Data\\rooms.json";
        private List<Room> allRoom = new List<Room>();


        public RoomRepository()
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
                    allRoom = JsonConvert.DeserializeObject<List<Room>>(json);
                }
            }
        }
        public void WriteToJson()
        {
            string json = JsonConvert.SerializeObject(allRoom);
            File.WriteAllText(fileLocation, json);
        }

        public List<Room> GetAll()
        {
            ReadJson();
            return allRoom;
        }

        public Room GetById(int id)
        {
            ReadJson();
            return allRoom.Find(obj => obj.Id == id);
        }
        public void Save(Room room)
        {

            allRoom.Add(room);
            WriteToJson();
        }

        public void Delete(int id)
        {
            ReadJson();
            int counter = 0;
            foreach (Room room in allRoom)
            {
                if (room.Id == id)
                    break;
                else
                    counter++;
            }
            //int index = allRoom.FindIndex(obj => obj.Id == id);
            allRoom.RemoveAt(counter);
            WriteToJson();
        }
        public void Update(Room room)
        {
            ReadJson();
            Room passedRoom = GetById(room.Id);
            passedRoom.Name = room.Name;
            passedRoom.Floor = room.Floor;

            WriteToJson();
        }
    }
}
