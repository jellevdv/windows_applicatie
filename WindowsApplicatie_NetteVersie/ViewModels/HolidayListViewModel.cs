using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WindowsApplicatie_NetteVersie.Models;
using Newtonsoft.Json;


namespace WindowsApplicatie_NetteVersie.ViewModels
{
    class HolidayListViewModel
    {
        //observable list of holidays
        public ObservableCollection<Holiday> Holidays { get; set; }

        public HolidayListViewModel()
        {
            Holidays = new ObservableCollection<Holiday>
            {
                new Holiday("Honeymoon", "Trip with wifey", "Hawaii", DateTime.Now),
                new Holiday("Hiking Trip", "Trip with friends", "Scotland", DateTime.Now)
            };

            //Haal data op
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

    }
}
