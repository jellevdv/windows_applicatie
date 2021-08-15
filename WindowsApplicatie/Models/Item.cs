using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApplicatie.Models
{

    public class Item : INotifyPropertyChanged
    {
        #region fields
        public string _name;
        public Category _category;

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region properties
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name can't be empty");
                }
                _name = value;
                NotifyPropertyChanged("Name");
            }
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public List<ItemTask> Tasks { get; set; }
        public Category Category { set; get; }

        #endregion

        #region constructor
        public Item(string name)
        {
            Name = name;
            Tasks = new List<ItemTask>();
        }

        public Item()
        {
            Tasks = new List<ItemTask>();
        }
        #endregion

        #region methods
        public void AddTask(ItemTask task)
        {
            if (Tasks.Contains(task))
            {
                throw new ArgumentException("Task is already added.");
            }
            Tasks.Add(task);
        }

        public void EditTask(ItemTask oldTask, ItemTask newTask)
        {
            if (!Tasks.Contains(oldTask))
            {
                throw new ArgumentException("Item doesn't exist.");
            }
            oldTask.Description = newTask.Description;
            oldTask.IsDone = newTask.IsDone;
        }
        #endregion
    }
}
