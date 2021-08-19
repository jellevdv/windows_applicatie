using System;
using System.Collections.ObjectModel;
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

        //All tasks of selected Item
        public ObservableCollection<ItemTask> ItemTasks { get; set; }

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

            Categories[0].AddItemToCategory(new Item("iPad", 1));
            Categories[0].AddItemToCategory(new Item("iPhone", 1));
            Categories[1].AddItemToCategory(new Item("Towels", 2));
            Categories[1].AddItemToCategory(new Item("Swim shorts", 1));

            Categories[0].Items[0].AddTaskToItem(new ItemTask("Opladen", false));
            Categories[0].Items[0].AddTaskToItem(new ItemTask("Nieuw hoesje aandoen", false));
            Categories[0].Items[1].AddTaskToItem(new ItemTask("Opladen", true));

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
