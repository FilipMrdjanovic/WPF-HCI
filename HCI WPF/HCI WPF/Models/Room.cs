using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_WPF.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Floor { get; set; }

        public static readonly Room Instance = new Room();
        public Room()
        {
        }

        public Room(int id, string name, int floor)
        {
            Id = id;
            Name = name;
            Floor = floor;
        }
    }
}
