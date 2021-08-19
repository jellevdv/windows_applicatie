using System;
using System.Collections.Generic;
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
using WindowsApplicatie_NetteVersie.Views;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WindowsApplicatie_NetteVersie
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
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
                        ContentFrame.Navigate(typeof(HolidayPage));
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
