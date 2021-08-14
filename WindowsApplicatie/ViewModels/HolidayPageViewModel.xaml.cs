using DocumentFormat.OpenXml.ExtendedProperties;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using Windows.UI.Xaml.Controls;
using WindowsApplicatie.Models;
using WindowsApplicatie.Views;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsApplicatie.ViewModels
{

    public sealed partial class HolidayPageViewModel : Page, INotifyPropertyChanged
    {
        public ObservableCollection<Holiday> Holidays { get; set; } //data
        public RelayCommand AddHolidayCommand { get; set; } //command om holiday toe te voegen
        public RelayCommand GoToSpecificHolidayCommand { get; set; } //command om naar specifieke holiday te gaan
        public event PropertyChangedEventHandler OnPropertyChanged; //voor als we op een bepaalde holiday klikken
        public event PropertyChangedEventHandler PropertyChanged;

        public Holiday selectedHoliday;
   

        public HolidayPageViewModel()
        {
            AddHolidayCommand = new RelayCommand((param) => AddHoliday(param));
            GoToSpecificHolidayCommand = new RelayCommand((param) => GoToSpecificHoliday(param));

            Holidays = new ObservableCollection<Holiday>();
            Holidays.Add(new Holiday("Honeymoon", "Hawaii", "Honeymoon for two weeks", DateTime.Now));
            Holidays.Add(new Holiday("Hiking trip", "Scotland", "Hikingtrip with friends", DateTime.Now));

            

            //HaalDataOp();
        }

        public Holiday SelectedHoliday
        {
            get
            {
                return selectedHoliday;
            }
            set
            {
                    selectedHoliday = value;
            }
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
            Holidays.Add(new Holiday() {Name=p.ToString(), Description="Test button nieuwe reis", Destination="Test", DepartureDate=DateTime.Now } );
        }

        private void GoToSpecificHoliday(object p)
        {
          //  Frame.Navigate(typeof(SpecificHolidayPage));
       //     this.Content = new SpecificHolidayPage();
        }





    }
}
