using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
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

namespace WindowsApplicatie.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HolidayPage : Page
    {

        public ObservableCollection<Holiday> Holidays = new ObservableCollection<Holiday>();

        public HolidayPage()
        {
            InitializeComponent();


            Holidays.Add(new Holiday("Honeymoon", "Hawaii", "Honeymoon for two weeks", DateTime.Now));
            Holidays.Add(new Holiday("Hiking trip", "Scotland", "Hikingtrip with friends", DateTime.Now));
            listViewHolidays.DataContext = Holidays;
        }

        private void ListView_SelectionChanged(object sender, RoutedEventArgs e)
        {
            //  mainFrame.Navigate(typeof(Views.CategoryPage));
            Console.WriteLine("clicked");
        }
    }
}
