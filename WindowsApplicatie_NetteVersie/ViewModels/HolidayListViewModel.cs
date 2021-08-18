using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Windows.Input;
using WindowsApplicatie_NetteVersie.Models;
using Xamarin.Forms;

namespace WindowsApplicatie_NetteVersie.ViewModels
{
    class HolidayListViewModel
    {
        public ICommand AddHolidayCommand => new Command(AddHoliday);
        public ICommand RemoveHolidayCommand => new Command(RemoveHoliday);

        public ObservableCollection<Holiday> Holidays { get; set; }

        public Holiday SelectedHoliday { get; set; }

        public HolidayListViewModel()
        {
            Holidays = new ObservableCollection<Holiday>
            {
                new Holiday("Honeymoon", "Trip with wifey", "Hawaii", DateTime.Now),
                new Holiday("Hiking Trip", "Trip with friends", "Scotland", DateTime.Now)
            };

            //HaalDataOp();
        }



        private async void HaalDataOp()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("https://localhost:44357/api/Holidays")); //string naar backend
            var lst = JsonConvert.DeserializeObject<ObservableCollection<Holiday>>(json);
            //   this.Movies = lst;
            foreach (Holiday h in lst)
            {
                this.Holidays.Add(h);
            }
        }

        public void AddHoliday()
        {
            Console.WriteLine("AddHolidayClicked");
        }

        public void RemoveHoliday()
        {
            Holidays.Remove(SelectedHoliday);
        }

    }
}
