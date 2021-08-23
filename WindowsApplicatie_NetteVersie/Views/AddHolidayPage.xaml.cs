using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using WindowsApplicatie_NetteVersie.Models;
using WindowsApplicatie_NetteVersie.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsApplicatie_NetteVersie.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddHolidayPage : Page
    {
        public AddHolidayPage()
        {
            this.InitializeComponent();
            _vm = new HolidayListViewModel();
            DataContext = _vm;
        }

        private async void Button_Create(object sender, RoutedEventArgs e)
        {
            if (Name.Text.Length <= 3)
            {
                Error.Text = "Name has to be minimum 3 characters long!";
                return;
            }

            if (Destination.Text.Length <= 3)
            {
                Error.Text = "Destination has to be minimum 3 characters long!";
                return;
            }

            if (Description.Text.Length <= 3)
            {
                Error.Text = "Destination has to be minimum 3 characters long!";
                return;
            }

            if (DepartureDate == null)
            {
                Error.Text = "Departure date is required!";
                return;
            }

            if (DepartureTime == null)
            {
                Error.Text = "Departure time is required!";
                return;
            }

            DateTime dt;

            try
            {
                var datetime = DepartureDate.Date.Value.DateTime.ToString().Split(" ")[0] + " " + DepartureTime.Time.ToString();
                dt = DateTime.Parse(datetime);
            }
            catch
            {
                Error.Text = "Departure date & time are required!";
                return;
            }


            if (dt < DateTime.Now)
            {
                Error.Text = "Departure date & time cannot be in the past!";
                return;
            }

            CustomError c = await _vm.AddHoliday(Name.Text, Description.Text, Destination.Text, dt);
            if (c.Message != null)
            {
                Error.Text = c.Message;
            }
            else
            {
                Frame.GoBack();
            }
        }

        private void Button_Cancel(object sender, RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
