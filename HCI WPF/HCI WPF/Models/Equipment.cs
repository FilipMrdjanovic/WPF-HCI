using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_WPF.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public string Location { get; set; }

        public static readonly Equipment Instance = new Equipment();
        public Equipment(int id, string name, int quantity, string location)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            Location = location;
        }

        public Equipment()
        {
        }
    }
}
