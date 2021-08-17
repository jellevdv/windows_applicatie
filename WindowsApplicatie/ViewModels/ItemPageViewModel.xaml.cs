using DocumentFormat.OpenXml.Packaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using WindowsApplicatie.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsApplicatie.ViewModels
{
    public sealed partial class ItemPageViewModel : Page
    {

  
        public ObservableCollection<Item> Items { get; set; }
        public object SelectedItem { get; set; }
        public RelayCommand AddItemCommand { get; set; } //command

        public ItemPageViewModel()
        {
           AddItemCommand = new RelayCommand((param) => AddItem(param));
            Items = new ObservableCollection<Item>
            {
                new Item("IPHONE"),
                new Item("TestObject")
            };
        }

        private async void HaalDataOp()
        {
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(new Uri("https://localhost:44357/api/Items")); //string naar API
            var lst = JsonConvert.DeserializeObject<ObservableCollection<Item>>(json);

            foreach (Item h in lst)
            {
                this.Items.Add(h);
            }
        }


        private void AddItem(object p)
        {
            Items.Add(new Item(p.ToString()));
        }
    }
}
