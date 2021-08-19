using System;
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

        private async void DisplayDeleteFileDialog()
        {



            ContentDialog deleteFileDialog = new ContentDialog
            {
                Title = "Delete file permanently?",
                Content = "If you delete this file, you won't be able to recover it. Do you want to delete it?",
                PrimaryButtonText = "Delete",
                CloseButtonText = "Cancel"
            };

            ContentDialogResult result = await deleteFileDialog.ShowAsync();

            // Delete the file if the user clicked the primary button.
            /// Otherwise, do nothing.
            if (result == ContentDialogResult.Primary)
            {
                // Delete the file.
            }
            else
            {
                // The user clicked the CLoseButton, pressed ESC, Gamepad B, or the system back button.
                // Do nothing.
            }
        }

        private async void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            ContentDialog deleteFileDialog = new ContentDialog
            {
                Title = "Error?",
                Content = "If you delete this file, you won't be able to recover it. Do you want to delete it?",
                PrimaryButtonText = "Delete",
                CloseButtonText = "Cancel"
            };

            ContentDialogResult result = await deleteFileDialog.ShowAsync();

            // Delete the file if the user clicked the primary button.
            /// Otherwise, do nothing.
            if (result == ContentDialogResult.Primary)
            {
                // Delete the file.
            }
            else
            {
                // The user clicked the CLoseButton, pressed ESC, Gamepad B, or the system back button.
                // Do nothing.
            }
        }


        private async void Button_Login(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(Email);
            System.Diagnostics.Debug.WriteLine(Passw);

            User u = await vm.Login();
            System.Diagnostics.Debug.WriteLine(u.ID);

            if (u.Token !=null)
            {
                Frame.Navigate(typeof(HolidayPage), u);
            }

            //if (c.Message != null)
            //{
            //    ContentDialog deleteFileDialog = new ContentDialog
            //    {
            //        Title = "Error?",
            //        Content = "There went something seriuously wrong... Please contact Admin!/n",
            //        PrimaryButtonText = "Delete",
            //        CloseButtonText = "Cancel"
            //    };

            //    ContentDialogResult result = await deleteFileDialog.ShowAsync();

            //    // Delete the file if the user clicked the primary button.
            //    /// Otherwise, do nothing.
            //    if (result == ContentDialogResult.Primary)
            //    {
            //        // Delete the file.
            //    }
            //    else
            //    {
            //        // The user clicked the CLoseButton, pressed ESC, Gamepad B, or the system back button.
            //        // Do nothing.
            //    }
            //}
        }
    }



}
