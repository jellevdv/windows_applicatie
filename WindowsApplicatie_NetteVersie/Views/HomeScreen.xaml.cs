﻿using System;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsApplicatie_NetteVersie.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomeScreen : Page
    {
        public HomeScreen()
        {
            this.InitializeComponent();
        }

        private void HolidayBtn_Click(object sender, RoutedEventArgs e)
        {
            //TODO go to page instead of replacing content
            HolidayPage mynewPage = new HolidayPage();
            this.Content = mynewPage;
        }

        private void CategoryBtn_Click(object sender, RoutedEventArgs e)
        {
            //TODO go to page instead of replacing content
            CategoryPage mynewPage = new CategoryPage(); 
            this.Content = mynewPage;
        }
    }
}
