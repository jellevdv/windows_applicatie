using System.Collections.Generic;
using System.ComponentModel;

namespace WindowsApplicatie_NetteVersie.Models
{
    public class Category : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }

        public Category()
        {
            Items = new List<Item>();
        }

        public Category(string name, string description, Item item)
        {
            Items = new List<Item>();
            Name = name;
            Description = description;
            Items.Add(item);
        }

    }
}
