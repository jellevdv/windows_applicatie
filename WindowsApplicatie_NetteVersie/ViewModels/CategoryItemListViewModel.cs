using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WindowsApplicatie_NetteVersie.Models;

namespace WindowsApplicatie_NetteVersie.ViewModels
{
    public class CategoryItemListViewModel
    {
        public Category selectedCategory { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Category> _categories { get; set; }

        public ObservableCollection<Category> Categories
        {
            get
            {
                return _categories;
            }
            set
            {
                _categories = value;
                this.OnPropertyChanged();
            }
        }



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

            RefreshData();
        }

        private void RefreshData()
        {
            var _user = AuthService.AppUser;


            System.Diagnostics.Debug.WriteLine("Getting Data For Categories");
            System.Diagnostics.Debug.WriteLine("Getting Data For Categories --- "+_user.Categories.Count);

            
            Categories = new ObservableCollection<Category>();
            foreach (var h in _user.Categories)
            {
                System.Diagnostics.Debug.WriteLine(h.Name);
                this.Categories.Add(h);
            }
            OnPropertyChanged("Holidays");
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

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
