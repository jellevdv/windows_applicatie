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
