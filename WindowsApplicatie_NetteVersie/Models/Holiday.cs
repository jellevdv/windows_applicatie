using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WindowsApplicatie_NetteVersie.Models
{
    public class Holiday : INotifyPropertyChanged
    {
        private string _name;
        private string _description;
        private string _destination;
        private DateTime _departureDate;
        private List<Category> _categories;


        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }
        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Description"));
            }
        }
        public string Destination
        {
            get
            {
                return _destination;
            }
            set
            {
                _destination = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Destination"));
            }
        }
        public DateTime DepartureDate
        {
            get
            {
                return _departureDate;
            }
            set
            {
                _departureDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DepartureDate"));
            }
        }
        public List<Category> Categories
        {
            get
            {
                return _categories;
            }
            set
            {
                _categories = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Categories"));
            }
        }
        public Holiday()
        {
            Categories = new List<Category>();
        }

        public Holiday(string name, string description, string destination, DateTime departuredate)
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
