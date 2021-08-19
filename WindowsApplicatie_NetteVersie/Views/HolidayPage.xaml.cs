using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Navigation;
using WindowsApplicatie_NetteVersie.Models;
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

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            User u = (User)e.Parameter;
            if (u != null)
            {
                vm._user = u;
            }
        }

    }
}
