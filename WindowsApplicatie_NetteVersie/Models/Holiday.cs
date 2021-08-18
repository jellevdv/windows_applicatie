using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApplicatie_NetteVersie.Models
{
    public class Holiday
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }

        public Holiday() { }

        public Holiday (string name, string description, string destination, DateTime departuredate)
        {
            Name = name;
            Description = description;
            Destination = destination;
            DepartureDate = departuredate;
        }


    }
}
