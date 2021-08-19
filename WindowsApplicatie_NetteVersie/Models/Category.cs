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

    }
}
