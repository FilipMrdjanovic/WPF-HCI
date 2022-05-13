using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_WPF.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }

        public static readonly Medicine Instance = new Medicine();
        public Medicine(int id, string name, int quantity)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
        }


        public Medicine()
        {
        }
    }
}
