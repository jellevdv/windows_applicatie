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
        private string _description;
        private bool _isDone;


        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Description"));
            }
        }

        public bool IsDone
        {
            get { return _isDone; }
            set
            {
                _isDone = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsDone"));
            }
        }

        public ItemTask() { }

        public ItemTask(string description, bool isDone)
        {
            Description = description;
            IsDone = isDone;
        }

        public void SetTaskAsCompleted()
        {
            IsDone = true;
        }
        public void SetTaskAsUnCompleted()
        {
            IsDone = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
