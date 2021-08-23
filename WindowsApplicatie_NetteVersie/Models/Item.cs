using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;

namespace WindowsApplicatie_NetteVersie.Models
{
    public class Item : INotifyPropertyChanged
    {
        public int ID { get; set; }
        private string _name;
        private int _count;
        public bool Packed;

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

        //public bool Packed
        //{
        //    get
        //    {
        //        return _packed;
        //    }
        //    set
        //    {
        //        _packed = value;
        //        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Packed"));
        //    }
        //}

        public Item()
        {
            //_packed = false;
        }

        public Item(string name)
        {
            //Packed = false;
            Name = name;
            //Count = count;
        }

        //public void SetItemAsPacked()
        //{
        //    this.Packed = true;
        //}
        //public void SetItemAsNotPacked()
        //{
        //    this.Packed = false;
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        public static explicit operator Item(JObject v)
        {
            Item u = new Item();

            try
            {
                u.ID = (int)v["id"];
                u.Name = (string)v["_name"];
                System.Diagnostics.Debug.WriteLine(u.Name);
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
