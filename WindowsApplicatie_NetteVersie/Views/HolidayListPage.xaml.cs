using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using WindowsApplicatie_NetteVersie.Models;
using WindowsApplicatie_NetteVersie.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsApplicatie_NetteVersie.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HolidayListPage : Page
    {

        public HolidayListPage()
        {
            this.InitializeComponent();
            _vm = new HolidayListViewModel();
            DataContext = _vm;
            //HolidayList.ItemsSource = AuthService.AppUser.Holidays;
        }

        private void HolidayListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _vm.SetSelectedHoliday(HolidayListView.SelectedItem as Holiday);
        }
        
        private void HolidayListView_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(HolidayDetailPage));
        }

        private void Button_AddNewHoliday(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(AddHolidayPage));
        }
    }
}
