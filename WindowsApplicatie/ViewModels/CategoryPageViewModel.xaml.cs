using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using Windows.UI.Xaml.Controls;
using WindowsApplicatie.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsApplicatie.ViewModels
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CategoryPageViewModel : Page
    {
      public ObservableCollection<Category> Categories { get; set; } //data
       // public RelayCommand AddCategoryCommand { get; set; } //command

        public CategoryPageViewModel()
        {
         //   AddCategoryCommand = new RelayCommand((param) => AddCategory(param));

            Categories = new ObservableCollection<Category>();

            Categories.Add(new Category("Electronics", "All electronic devices"));
            Categories.Add(new Category("Handluggage", "All I need to have a good time on the airplane"));
            Categories.Add(new Category("Swim apparal", "Pool stuff"));



            //HaalDataOp();
        }

        private async void HaalDataOp()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("https://localhost:44357/api/Holidays")); //string naar API
            var lst = JsonConvert.DeserializeObject<ObservableCollection<Category>>(json);

            foreach (Category h in lst)
            {
                this.Categories.Add(h);
            }
        }


        private void AddCategory(object p)
        {
            Categories.Add(new Category(p.ToString(), "All electronic devices"));
        }

    }
}
