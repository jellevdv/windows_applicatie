using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WindowsApplicatie_NetteVersie.Models;
using Xamarin.Forms;

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


        public string ItemName { get; set; }

        public string TaskDescription { get; set; }

        //Add item to category
        public ICommand AddItemCommand => new Command(AddItem);
        public ICommand AddItemTaskCommand => new Command(AddItemTask);



        public ICommand HandleCheckCommand => new Command(HandleCheck);


        public ICommand HandleUncheckedCommand => new Command(HandleUnchecked);



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
            Categories[1].Items[0].SetItemAsPacked();
            Categories[1].AddItemToCategory(new Item("Swim shorts", 1));

            Categories[0].Items[0].AddTaskToItem(new ItemTask("Opladen", false));
            Categories[0].Items[0].AddTaskToItem(new ItemTask("Nieuw hoesje aandoen", true));
            Categories[0].Items[1].AddTaskToItem(new ItemTask("Opladen", false));

            //HaalDataOp();
        }




        private void HandleCheck(object obj)
        {
            Console.WriteLine("Checked");
        }

        private void HandleUnchecked(object obj)
        {
            Console.WriteLine("Unchecked");
        }


        public void AddCategoryToHoliday(Category category)
        {
            Categories.Add(category);
        }


        public void AddItem()
        {
            //TODO amount of items
            SelectedCategory.AddItemToCategory(new Item(ItemName,1));
        }

        public void AddItemTask()
        {
            SelectedItem.AddTaskToItem(new ItemTask(TaskDescription, false));
        }
    }
}
