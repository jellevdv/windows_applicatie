using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApplicatie_NetteVersie.Models
{
    public class Holiday : INotifyPropertyChanged
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public List<Category> Categories { get; set; }

        public Holiday() {
            Categories = new List<Category>();
        }

        public Holiday (string name, string description, string destination, DateTime departuredate)
        {
            Categories = new List<Category>();
            Name = name;
            Description = description;
            Destination = destination;
            DepartureDate = departuredate;
        }

        public void AddCategoryToHoliday(Category category)
        {
            Categories.Add(category);
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
