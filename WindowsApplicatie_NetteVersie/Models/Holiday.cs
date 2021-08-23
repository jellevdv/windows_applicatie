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
        public List<Item> _items;


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
                u.ID = (int)v["id"];
                u.Name = (string)v["_name"];
                u.Description = (string)v["_description"];
                u.Destination = (string)v["_destination"];
                System.Diagnostics.Debug.WriteLine((string)v["_departuredate"]);
                System.Diagnostics.Debug.WriteLine(DateTime.Parse((string)v["_departuredate"]));
                u.DepartureDate = DateTime.Parse((string)v["_departuredate"]);

                u._items = new List<Item>();

                foreach (var d in v["_items"].Children())
                {
                   
                    Item i = (Item)d["item"];
                    i.Count = (int)d["count"];
                    i.Packed = true;
                    System.Diagnostics.Debug.WriteLine("HOLIDAY RESOLVER ==== " +i.Name);
                    u._items.Add(i);
                }
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
