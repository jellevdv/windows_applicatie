using GalaSoft.MvvmLight.Command;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using Windows.UI.Xaml.Controls;
using WindowsApplicatie.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsApplicatie.ViewModels
{

    public sealed partial class HolidayPageViewModel : Page
    {
        public ObservableCollection<Holiday> Holidays { get; set; } //data
        public RelayCommand AddHolidayCommand { get; set; } //command

        public HolidayPageViewModel()
        {
            AddHolidayCommand = new RelayCommand((param) => AddHoliday(param));

            Holidays = new ObservableCollection<Holiday>();
            Holidays.Add(new Holiday("Honeymoon", "Hawaii", "Honeymoon for two weeks", DateTime.Now));
            Holidays.Add(new Holiday("Hiking trip", "Scotland", "Hikingtrip with friends", DateTime.Now));

            

            //HaalDataOp();
        }

        private async void HaalDataOp()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("https://localhost:44357/api/Holidays")); //string naar API
            var lst = JsonConvert.DeserializeObject<ObservableCollection<Holiday>>(json);
            //   this.Movies = lst;
            foreach (Holiday h in lst)
            {
                this.Holidays.Add(h);
            }
        }


        private void AddHoliday(object p)
        {
            Holidays.Add(new Holiday("Honeymoon", "Hawaii", "Honeymoon for two weeks", DateTime.Now));
            Holidays.Add(new Holiday("Hiking trip", "Scotland", "Hikingtrip with friends", DateTime.Now));
        }
    }
}
