using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace WindowsApplicatie_NetteVersie.Models
{
    public class Item : INotifyPropertyChanged
    {
        private string _name;
        private int _count;
        private bool _packed;
        private List<ItemTask> _itemTasks;
       


        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
            }
        }

        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Count"));
            }
        }

        public bool Packed
        {
            get
            {
                return _packed;
            }
            set
            {
                _packed = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Packed"));
            }
        }


        public List<ItemTask> ItemTasks
        {
            get
            {
                return _itemTasks;
            }
            set
            {
                _itemTasks = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ItemTasks"));
            }
        }

        public Item()
        {
            ItemTasks = new List<ItemTask>();
            _packed = false;
        }

        public Item(string name, int count)
        {
            ItemTasks = new List<ItemTask>();
            Packed = false;
            Name = name;
            Count = count;
        }

        public void AddTaskToItem(ItemTask itemTask)
        {
            ItemTasks.Add(itemTask);
        }
        public void SetItemAsPacked()
        {
            this.Packed = true;
        }
        public void SetItemAsNotPacked()
        {
            this.Packed = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;


    }
}
