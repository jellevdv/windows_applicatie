using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WindowsApplicatie_NetteVersie.Models
{
    public class Holiday : INotifyPropertyChanged
    {
        public int ID { get; set; }
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

        public static explicit operator Holiday(JToken v)
        {
            Holiday u = new Holiday();

            try
            {
                u.Name = (string)v["_name"];
                u.Description = (string)v["_description"];
                u.Destination = (string)v["_destination"];
                u.DepartureDate = (DateTime)v["_departuredate"];
                //   u.Categories = (Category)v["categories"];
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("Something went wrong mapping the holiday in user...!");
                throw new Exception();
            }

            return u;
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
