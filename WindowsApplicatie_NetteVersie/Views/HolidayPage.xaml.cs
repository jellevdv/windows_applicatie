using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsApplicatie_NetteVersie.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HolidayPage : Page
    {
        public HolidayPage()
        {
            this.InitializeComponent();
        }

        private void AddHolidayBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!Popup.IsOpen) { Popup.IsOpen = true; }
        }
        public void ClosePopupClicked(object sender, RoutedEventArgs e)
        {
            if (Popup.IsOpen) { Popup.IsOpen = false; }
        }
    }
}
