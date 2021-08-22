using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WindowsApplicatie_NetteVersie.Models;
using Xamarin.Forms;

namespace WindowsApplicatie_NetteVersie.ViewModels
{
    public class HolidayDetailViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Holiday _holiday { get; set; }

        //The holiday for which you are packing
        public Holiday Holiday { get { return _holiday; } set { _holiday = value; OnPropertyChanged("Holiday"); OnPropertyChanged("_holiday"); } }

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
            Holiday = HolidayService.SelectedHoliday;
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
            SelectedCategory.AddItemToCategory(new Item(ItemName, 1));
        }

        public void AddItemTask()
        {
            SelectedItem.AddTaskToItem(new ItemTask(TaskDescription, false));
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
