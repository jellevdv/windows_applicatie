using System;
using Windows.UI.Xaml.Controls;
using WindowsApplicatie_NetteVersie.Models;
using WindowsApplicatie_NetteVersie.ViewModels;

namespace WindowsApplicatie_NetteVersie.Views
{
    public sealed partial class RegisterPage : Page
    {
        AuthViewModel vm;

        public RegisterPage()
        {
            this.InitializeComponent();
            vm = new AuthViewModel();
            DataContext = vm;
        }

        private async void Button_Register(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var t = Error;

            if (!Passw.Password.ToString().Equals(PasswConfirm.Password.ToString()))
            {
                t.Text = "Passwords do not match!";
                return;
            }

            ContentDialog w = new ContentDialog
            {
                Title = "One moment please...",
                Content = "Check your connection and try again.",
            };

            (User u, CustomError c) = await vm.Register(DatePicker.Date);
            //await w.ShowAsync();

            System.Diagnostics.Debug.WriteLine("Waiting....");

            //if (u != null)
            //    w.Hide();

            if (c.Message != null)
            {
                t.Text = c.Message;
            }
            else if (u.Token != null)
            {
                Frame.Navigate(typeof(HolidayPage));
            }
            else
            {
                t.Text = "Something went wrong... Please try again.";
            }
        }
    }



}
