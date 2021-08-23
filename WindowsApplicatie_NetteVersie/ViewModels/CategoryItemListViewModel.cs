using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using WindowsApplicatie_NetteVersie.Models;
using Xamarin.Forms;

namespace WindowsApplicatie_NetteVersie.ViewModels
{
    public class CategoryItemListViewModel
    {
        public Category selectedCategory { get; set; }

        public ObservableCollection<Category> Categories { get; set; }
        
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }


        public Category SelectedCategory { get; set; }

        public CategoryItemListViewModel()
        {
            Categories = new ObservableCollection<Category>();
            //{
            //    new Category("Electronics", "All our electronic devices"),
            //    new Category("Watergear", "Everything we need to swim"),
            //    new Category("Handluggage","For in the plane"),
            //    new Category("Test","test")
            //};

            //Item i = new Item("hairdwqerfe", 3);

            //Categories[0].Items = new List<Item>();
            //Categories[0].Items.Add(i);

            foreach(var c in AuthService.AppUser.Categories)
            {
                Categories.Add(c);
            }



            //   HaalDataOp();
        }

        public async Task<CustomError> AddCategory(string name)
        {
            Category category = new Category(name, "");
            (Category cat, CustomError c) = await HolidayService.AddCategory(category);
            if (cat.ID >= 0 && c.Message == null)
            {
                Categories.Add(cat);
            }

            return c;
        }

        internal void SetSelectedCategory(Category category)
        {
            selectedCategory = category;
        }
    }
}
