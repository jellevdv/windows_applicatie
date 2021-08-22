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

            //_navigationService.Navigate(typeof(ContentGridDetailPage), clickedItem.OrderID);
            //_navigationService.NavigateTo(ItemPage);
            System.Diagnostics.Debug.WriteLine(vm.SelectedHoliday.Name);
            Frame.Navigate(typeof(HolidayDetailPage), vm.SelectedHoliday);


        }



        private void AddHoliday_Button(object sender, RoutedEventArgs e)
        {
            
            System.Diagnostics.Debug.WriteLine(DepartureTime.Time.ToString());

            var datetime = HolidayDepartureDate.Date.Value.DateTime.ToString().Split(" ")[0] + " " + DepartureTime.Time.ToString();

            System.Diagnostics.Debug.WriteLine(datetime);

            DateTime dt = DateTime.Parse(datetime);

            System.Diagnostics.Debug.WriteLine(dt.Date.ToString());

            vm.AddHoliday(dt);
        }
    }
}
