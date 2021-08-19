using System.Collections.Generic;
using System.ComponentModel;
using Windows.UI.Xaml.Controls.Primitives;

namespace WindowsApplicatie_NetteVersie.Models
{
    public class Category : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

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
        public List<Item> Items { get
            {
                return _items;
            } set
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

    }
}
