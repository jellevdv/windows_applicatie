using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WindowsApplicatie_NetteVersie.Models
{
    public class Category : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int ID { get; set; }
        private string _name;
        private string _description;
        private List<Item> _items;

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
        public List<Item> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Items"));
            }
        }

        public Category()
        {
            Items = new List<Item>();
        }

        public Category(string name, string description)
        {
            Items = new List<Item>();
            Name = name;
            Description = description;
        }

        public void AddItemToCategory(Item item)
        {
            Items.Add(item);
        }

        public static explicit operator Category(JToken v)
        {
            Category u = new Category();

            try
            {
                u.ID = (int)v["id"];
                u.Name = (string)v["_name"];
                u.Description = "";

                u.Items = new List<Item>();

                foreach (var d in v["items"].Children())
                {
                    Item i = (Item)d;
                    u.Items.Add(i);
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
    }
}
