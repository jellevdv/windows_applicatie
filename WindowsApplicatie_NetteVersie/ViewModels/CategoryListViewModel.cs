using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using WindowsApplicatie_NetteVersie.Models;
using Xamarin.Forms;

namespace WindowsApplicatie_NetteVersie.ViewModels
{
    public class CategoryListViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }

        public ICommand AddCategoryCommand => new Command(AddCategory);

        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }


        public Category SelectedCategory { get; set; }

        public CategoryListViewModel()
        {
            Categories = new ObservableCollection<Category>
            {
                new Category("Electronics", "All our electronic devices"),
                new Category("Watergear", "Everything we need to swim"),
                new Category("Handluggage","For in the plane"),
                new Category("Test","test")
            };

            //   HaalDataOp();
        }


        private void AddCategory()
        {
            Categories.Add(new Category(CategoryName, CategoryDescription));
            CategoryName = "";
            CategoryDescription = "";
        }
    }
}
