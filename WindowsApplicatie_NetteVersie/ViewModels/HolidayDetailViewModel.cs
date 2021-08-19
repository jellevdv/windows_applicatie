using GalaSoft.MvvmLight;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WindowsApplicatie_NetteVersie.Models;

namespace WindowsApplicatie_NetteVersie.ViewModels
{
    public class HolidayDetailViewModel
    {
        public Holiday Holiday { get; set; }
        public ObservableCollection<Category> Categories { get; set; }
        public Category SelectedCategory { get; set; }


        public HolidayDetailViewModel()
        {
            Holiday = new Holiday("Honeymoon", "Trip with waifu", "Hawaii", DateTime.Now);
            Categories = new ObservableCollection<Category>
            {
                new Category("Electronics", "All our electronic devices"),
                new Category("Watergear", "Everything we need to swim"),
                new Category("Handluggage","For in the plane")
            };

            //HaalDataOp();
        }



        private async void HaalDataOp()
        {
        }

        public void AddCategoryToHoliday(Category category)
        {
            Categories.Add(category);
        }
    }
}
