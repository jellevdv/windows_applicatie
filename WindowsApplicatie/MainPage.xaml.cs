using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WindowsApplicatie.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WindowsApplicatie
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            this.DataContext = new MainPageViewModel();
        }

        private void List_SelectionChanged(object sender, RoutedEventArgs e)
        {
            //  mainFrame.Navigate(typeof(Views.HomePage));
            Console.WriteLine(sender.ToString());
        }

        private void Holidays_clicked(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(Views.HolidayPage));
        }

        private void Categories_clicked(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(Views.CategoryPage));
        }

        private void Items_clicked(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(Views.ItemPage));
        }


        private void TestPageClicked(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(typeof(Views.TestPage));
        }
    }
}
