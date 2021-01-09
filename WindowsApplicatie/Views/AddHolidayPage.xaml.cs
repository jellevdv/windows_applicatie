using Windows.UI.Xaml.Controls;
using WindowsApplicatie.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsApplicatie.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddHolidayPage : Page
    {
        public AddHolidayPage()
        {
            InitializeComponent();
            this.DataContext = new AddHolidayViewModel();
        }
    }
}
