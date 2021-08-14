using DocumentFormat.OpenXml.Drawing.Charts;
using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WindowsApplicatie.Models;
using WindowsApplicatie.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsApplicatie.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HolidayPage : Page
    {

        public HolidayPage()
        {
            InitializeComponent();
            this.DataContext = new HolidayPageViewModel();
        }
        //TODO moet nog in viewmodel ipv view zelf
        public void ClosePopupClicked(object sender, RoutedEventArgs e)
        {
            // if the Popup is open, then close it
          //  if (StandardPopup.IsOpen) { StandardPopup.IsOpen = false; }
        }

        // Handles the Click event on the Button on the page and opens the Popup. 
        private void ShowPopupOffsetClicked(object sender, RoutedEventArgs e)
        {
            // open the Popup if it isn't open already 
          //  if (!StandardPopup.IsOpen) { StandardPopup.IsOpen = true; }
        }

        private void ListViewHolidays_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(sender);
        }
    }
}
