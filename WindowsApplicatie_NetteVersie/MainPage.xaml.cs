using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WindowsApplicatie_NetteVersie.Models;
using WindowsApplicatie_NetteVersie.Views;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WindowsApplicatie_NetteVersie
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private User _user;

        public void SetUser(User u)
        {
            this._user = u;
        }

        public User GetUser()
        {
            return this._user;
        }

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(LoginPage));
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                //if you have settings page code here
            }
            else
            {
                NavigationViewItem item = args.SelectedItem as NavigationViewItem;
                switch (item.Tag.ToString())
                {
                    case "LoginPage":
                        ContentFrame.Navigate(typeof(LoginPage));
                        break;
                    case "HolidayPage":
                        ContentFrame.Navigate(typeof(HolidayPage), AuthService.AppUser);
                        break;
                    case "CategoryPage":
                        ContentFrame.Navigate(typeof(CategoryPage));
                        break;
                    case "ItemPage":
                        ContentFrame.Navigate(typeof(ItemPage));
                        break;
                    case "TestPage":
                        ContentFrame.Navigate(typeof(HolidayDetailPage));
                        break;
                }
            }
        }
    }
}
