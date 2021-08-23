using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using WindowsApplicatie_NetteVersie.Models;
using WindowsApplicatie_NetteVersie.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsApplicatie_NetteVersie.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HolidayDetailPage : Page
    {
        //private HolidayDetailViewModel _vm;

        public HolidayDetailPage()
        {
            this.InitializeComponent();
            _vm = new HolidayDetailViewModel();
            DataContext = _vm;

            Name.Text = "Holiday Details - " + _vm.Holiday.Name;
            Destination.Text = "Destination: " + _vm.Holiday.Destination;
            DepartureDate.Text = "Departure Date: " + _vm.Holiday.DepartureDate.ToLongTimeString();
            Description.Text = "Description: " + _vm.Holiday.Description;

            ItemListView.ItemsSource = _vm.Holiday._items;

            List<HolidayTask> tasks = new List<HolidayTask>();

            HolidayTask t1 = new HolidayTask("Get new ID card.", false);
            HolidayTask t2 = new HolidayTask("Find babysitter for cat.", false);
            HolidayTask t3 = new HolidayTask("Work hard to save 1k euros. ", true);

            tasks.Add(t1);
            tasks.Add(t2);
            tasks.Add(t3);

            TaskListView.ItemsSource = tasks;
        }

        private void Button_AddNewItem(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }
    }
}
