using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_WPF.Models
{
    public class Renovation
    {
        public int Id { get; set; }
        public string TypeOfRenovation { get; set; }
        public string Description { get; set; }

        public static readonly Renovation Instance = new Renovation();
        public Renovation(int id, string typeOfRenovation, string description)
        {
            Id = id;
            TypeOfRenovation = typeOfRenovation;
            Description = description;
        }

        public Renovation()
        {
        }
    }
}
