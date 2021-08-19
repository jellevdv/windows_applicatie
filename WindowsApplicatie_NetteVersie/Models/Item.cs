using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApplicatie_NetteVersie.Models
{
    public class Item : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public Category Category { get; set; }
        public int Count { get; set; }
        public List<ItemTask> ItemTasks { get; set; }

        public Item() {
            ItemTasks = new List<ItemTask>();
        }

        public Item(string name, Category category, int count)
        {
            ItemTasks = new List<ItemTask>();
            Name = name;
            Category = category;
            Count = count;
        }

        public void AddTaskToItem(ItemTask itemTask)
        {
            ItemTasks.Add(itemTask);
        }

        public event PropertyChangedEventHandler PropertyChanged;


    }
}
