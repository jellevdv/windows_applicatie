using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApplicatie_NetteVersie.Models
{
    public class ItemTask : INotifyPropertyChanged
    {
        public string Description { get; set; }
        public bool IsDone { get; set; }
        public Item Item { get; set; }

        public ItemTask() { }

        public ItemTask(string description, bool isDone, Item item)
        {
            Description = description;
            IsDone = isDone;
            Item = item;
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
