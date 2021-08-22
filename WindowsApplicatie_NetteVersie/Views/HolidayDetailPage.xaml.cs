using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
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
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine((e.Parameter as Holiday).Name);
            //_vm.Holiday = (e.Parameter as Holiday);
            _vm.InitializeHoliday((e.Parameter as Holiday).ID);
            base.OnNavigatedTo(e);
        }
    }
}
