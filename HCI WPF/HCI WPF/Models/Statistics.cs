using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCI_WPF.Models
{
    public class Statistics
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Stars { get; set; }
        public int Overall { get; set; }

        public static readonly Statistics Instance = new Statistics();

        public Statistics(int id, string description, int stars, int overall)
        {
            Id = id;
            this.Description = description;
            this.Stars = stars;
            this.Overall = overall;
        }

        public Statistics()
        {
        }
    }
}
