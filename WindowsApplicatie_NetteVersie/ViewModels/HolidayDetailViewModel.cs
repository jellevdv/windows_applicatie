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
        //The holiday for which you are packing
        public Holiday Holiday { get; set; }

        //All categories
        public ObservableCollection<Category> Categories { get; set; }

        //All items of the selected Category
        public ObservableCollection<Item> Items { get; set; }

        //Selected category from listview
        public Category SelectedCategory { get; set; }

        //selected item from listview
        public Item SelectedItem { get; set; }


        public HolidayDetailViewModel()
        {
            Holiday = new Holiday("Honeymoon", "Trip with waifu", "Hawaii", DateTime.Now);
            Categories = new ObservableCollection<Category>
            {
                new Category("Electronics", "All our electronic devices"),
                new Category("Watergear", "Everything we need to swim"),
                new Category("Handluggage","For in the plane"),
                new Category("Test","test")
        
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
