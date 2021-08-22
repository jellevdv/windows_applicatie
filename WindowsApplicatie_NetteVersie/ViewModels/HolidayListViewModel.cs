﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Windows.UI.Xaml.Controls;
using WindowsApplicatie_NetteVersie.Models;
using Xamarin.Forms;

namespace WindowsApplicatie_NetteVersie.ViewModels
{
    public class HolidayListViewModel
    {
        public ICommand RemoveHolidayCommand => new Command(RemoveHoliday);

        public event PropertyChangedEventHandler PropertyChanged;

        public User _user { get; set; }

        private ObservableCollection<Holiday> _holidays { get; set; }

        public ObservableCollection<Holiday> Holidays
        {
            get
            {
                return _holidays;
            }
            set
            {
                _holidays = value;
                this.OnPropertyChanged();
            }
        }

        public Holiday SelectedHoliday { get; set; }

        public string HolidayName { get; set; }
        public string HolidayDestination { get; set; }
        public string HolidayDescription { get; set; }
        public DateTime HolidayDepartureDate { get; set; }


        public HolidayListViewModel()
        {
            //Holidays = new ObservableCollection<Holiday>
            //{
            //    new Holiday("Honeymoon", "Trip with waifu", "Hawaii", DateTime.Now),
            //    new Holiday("Hiking Trip", "Trip with friends", "Scotland", DateTime.Now)
            //};

            Holidays = new ObservableCollection<Holiday>();
            RefreshData();

            //HaalDataOp();
        }

        private void RefreshData()
        {
            _user = AuthService.AppUser;
            Holidays = new ObservableCollection<Holiday>();
            foreach (var h in _user.Holidays)
            {
                Holidays.Add(h);
            }
            OnPropertyChanged("Holidays");
        }
        
        public async void AddHoliday(DateTime holidayDepartureDate)
        {
            Holiday holiday = new Holiday(HolidayName, HolidayDescription, HolidayDestination, holidayDepartureDate);
            (Holiday h, CustomError c) = await HolidayService.AddHoliday(holiday);
            if (h.ID >= 0 && c.Message == null)
            {
                Holidays.Add(h);
            }
        }

        public void RemoveHoliday()
        {
            Console.WriteLine("Delete clicked");
            Holidays.Remove(SelectedHoliday);
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
