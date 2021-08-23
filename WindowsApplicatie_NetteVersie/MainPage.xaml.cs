using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
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
            _user = AuthService.AppUser;

            this.InitializeComponent();
            this.navView.IsPaneVisible = false;
            this.navView.IsPaneOpen = false;
            this.navView.IsPaneToggleButtonVisible = false;
            this.navView.PaneDisplayMode = NavigationViewPaneDisplayMode.LeftMinimal;

            if (_user != null)
            {
                if (_user.Token != null)
                    DisplayNav();
            }
        }

        public void DisplayNav()
        {
            this.navView.PaneDisplayMode = NavigationViewPaneDisplayMode.LeftCompact;
            this.navView.IsPaneVisible = true;
            //this.navView.IsPaneOpen = true;
            this.navView.IsPaneToggleButtonVisible = true;
        }

        private void NavigationView_Loaded(object sender, RoutedEventArgs e)
        {
            ContentFrame.Navigate(typeof(LoginPage));
        }

        private void NavigationView_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            //use the MyFindListBoxChildOfType method from the link.
            var MyFrame = MyFindListBoxChildOfType<Frame>(navView);
            if (MyFrame.CanGoBack)
            {                
                if (MyFrame.BackStack[MyFrame.BackStack.Count - 1].SourcePageType != typeof(LoginPage))
                    MyFrame.GoBack();
            }
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
                _user = AuthService.AppUser;
                if (_user != null)
                {
                    DisplayNav();
                    switch (item.Tag.ToString())
                    {
                        case "HomePage":
                            ContentFrame.Navigate(typeof(HomeScreen));
                            break;
                        case "HolidayPage":
                            ContentFrame.Navigate(typeof(HolidayListPage));
                            break;                        
                        case "CategoryPage":
                            ContentFrame.Navigate(typeof(CategoryItemPage));
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

        public static T MyFindListBoxChildOfType<T>(DependencyObject root) where T : class
        {
            var MyQueue = new Queue<DependencyObject>();
            MyQueue.Enqueue(root);
            while (MyQueue.Count > 0)
            {
                DependencyObject current = MyQueue.Dequeue();
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(current); i++)
                {
                    var child = VisualTreeHelper.GetChild(current, i);
                    var typedChild = child as T;
                    if (typedChild != null)
                    {
                        return typedChild;
                    }
                    MyQueue.Enqueue(child);
                }
            }
            return null;
        }

    }
}
