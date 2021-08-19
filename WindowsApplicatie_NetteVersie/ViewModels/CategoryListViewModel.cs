using System.Collections.ObjectModel;
using WindowsApplicatie_NetteVersie.Models;

namespace WindowsApplicatie_NetteVersie.ViewModels
{
    public class CategoryListViewModel
    {
        public ObservableCollection<Category> Categories { get; set; }

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
    }
}
