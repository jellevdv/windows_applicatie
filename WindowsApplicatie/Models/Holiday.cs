﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsApplicatie.Models
{
    public class Holiday : INotifyPropertyChanged
    {
        #region fields
        public string _name;
        public string _description;
        public string _destination;
        public DateTime _departuredate;

        #endregion

        #region Properties
        public int Id { get; set; }

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
        public string Description
        {
            get
            {
                return _description;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Description can't be empty");
                }
                _description = value;
            }
        }
        public string Destination
        {
            get
            {
                return _destination;
            }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Destination can't be empty");
                }
                _destination = value;
            }
        }
        public List<User> Users { get; set; }
        public List<HolidayCategory> Categories { get; set; }
        public DateTime DepartureDate { get; set; }
        #endregion

        #region constructor
        public Holiday(string name, string destination, string description, DateTime departuredate)
        {
            Name = name;
            Description = description;
            Destination = destination;
            Users = new List<User>();
            Categories = new List<HolidayCategory>();
            DepartureDate = departuredate;
        }

        public Holiday()
        {
            Users = new List<User>();
            Categories = new List<HolidayCategory>();
        }
        #endregion

        #region methods
        public void AddCategory(Category category)
        {
            if (Categories.Where(c => c.CategoryId == category.Id).Any())
            {
                throw new ArgumentException("Category is already added.");
            }
            HolidayCategory holidayCategory = new HolidayCategory(this, category);
            Categories.Add(holidayCategory);
            category.Holidays.Add(holidayCategory);
        }

        public void AddUser(User user)
        {
            if (Users.Contains(user))
            {
                throw new ArgumentException("Category is already added.");
            }
            Users.Add(user);
        }

        public event PropertyChangedEventHandler OnPropertyChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = OnPropertyChanged;
            if(null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void RaisePropertyChanged([CallerMemberName]string propertyName = "")
        {
            OnPropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
