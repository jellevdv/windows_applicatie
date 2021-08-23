﻿using System;
using Windows.UI.Xaml;
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

       
            MainPage mainPage = (Window.Current.Content as Frame).Content as MainPage;
            mainPage.DisplayNav();

            if (u.Token != null)
            {
                Frame.Navigate(typeof(HolidayListPage));
            }
        }

        private async void Button_Register(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegisterPage));
        }
    }
}
