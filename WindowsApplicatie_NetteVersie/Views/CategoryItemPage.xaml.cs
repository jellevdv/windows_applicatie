using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using WindowsApplicatie_NetteVersie.Models;
using WindowsApplicatie_NetteVersie.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsApplicatie_NetteVersie.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CategoryItemPage : Page
    {
        public CategoryItemPage()
        {
            this.InitializeComponent();
            _vm = new CategoryItemListViewModel();
            this.DataContext = _vm;
        }

        private async void Button_AddNewItem(object sender, RoutedEventArgs e)
        {
            CustomError c = await _vm.AddItem(ItemName.Text);
            if (c.Message != null)
            {
                Error.Text = c.Message;
            }
            else
            {
                Error.Text = "";
               ItemName.Text = "";
            }
        }

        private async void Button_AddNewCategory(object sender, RoutedEventArgs e)
        {
            CustomError c = await _vm.AddCategory(CategoryName.Text);
            if (c.Message != null)
            {
                Error.Text = c.Message;
            }
            else
            {
                Error.Text = "";
                CategoryName.Text = "";
            }
        }

        private void CategoryListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _vm.SetSelectedCategory(CategoryListView.SelectedItem as Category);
            ItemGrid.Visibility = Visibility.Visible;
            ItemListView.ItemsSource = _vm.SelectedCategory.Items;
        }

        private void CategoryListView_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(HolidayDetailPage));
        }

        private void ItemListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _vm.SetSelectedCategory(CategoryListView.SelectedItem as Category);
            ItemListView.Visibility = Visibility.Visible;
        }

        private void ItemListView_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(HolidayDetailPage));
        }
    }

}
