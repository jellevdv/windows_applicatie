﻿using DocumentFormat.OpenXml.Wordprocessing;
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


    }
}
