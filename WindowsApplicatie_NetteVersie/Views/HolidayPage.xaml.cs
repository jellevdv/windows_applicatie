using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using WindowsApplicatie_NetteVersie.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsApplicatie_NetteVersie.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HolidayPage : Page
    {

        HolidayListViewModel vm { get; set; }

        //private readonly INavigationService _navigationService;


        public HolidayPage()
        {
            this.InitializeComponent();
            vm = new HolidayListViewModel();
            DataContext = vm;
        }

        private void AddHolidayBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!Popup.IsOpen) { Popup.IsOpen = true; }
        }
        public void ClosePopupClicked(object sender, RoutedEventArgs e)
        {
            if (Popup.IsOpen) { Popup.IsOpen = false; }
        }

        private void GoToDetailScreenHoliday_Click(object sender, RoutedEventArgs e)
        {
            vm.SetSelectedHoliday(vm.SelectedHoliday);
            Frame.Navigate(typeof(HolidayDetailPage));
        }



        private void AddHoliday_Button(object sender, RoutedEventArgs e)
        {
            var datetime = HolidayDepartureDate.Date.Value.DateTime.ToString().Split(" ")[0] + " " + DepartureTime.Time.ToString();        
            DateTime dt = DateTime.Parse(datetime);
            vm.AddHoliday(dt);
        }
    }
}
