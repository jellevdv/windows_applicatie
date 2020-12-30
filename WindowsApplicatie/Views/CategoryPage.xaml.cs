using DocumentFormat.OpenXml.Office.CustomUI;
using DocumentFormat.OpenXml.Office2013.Drawing.Chart;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using WindowsApplicatie.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsApplicatie.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CategoryPage : Page
    {
        public ObservableCollection<Category> Categories = new ObservableCollection<Category>();

        public CategoryPage()
        {
            InitializeComponent();

            Categories.Add(new Category("Electronics", "All electronic devices"));
            Categories.Add(new Category("Handluggage", "All I need to have a good time on the airplane"));
            Categories.Add(new Category("Swim apparal", "Pool stuff"));
            CategoryList.DataContext = Categories;
        }
    }
}
