using System;
using Windows.UI.Xaml.Controls;
using WindowsApplicatie_NetteVersie.Models;
using WindowsApplicatie_NetteVersie.ViewModels;

namespace WindowsApplicatie_NetteVersie.Views
{
    public sealed partial class LoginPage : Page
    {
        AuthViewModel vm;

        public LoginPage()
        {
            this.InitializeComponent();
            vm = new AuthViewModel();
            DataContext = vm;
        }


        private async void Button_Login(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(Email);
            System.Diagnostics.Debug.WriteLine(Passw);

            User u = await vm.Login();
            System.Diagnostics.Debug.WriteLine(u.ID);

            if (u.Token != null)
            {
                Frame.Navigate(typeof(HolidayPage));
            }
        }

        private async void Button_Register(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegisterPage));
        }
    }
}
