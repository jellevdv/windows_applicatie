using Windows.UI.Xaml.Controls;
using WindowsApplicatie.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsApplicatie.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TestPage : Page
    {


        public TestPage()
        {
            this.InitializeComponent();
            lvEmployees.ItemsSource = new string[] { "Jelle Vandevyvere", "Kadir Olmez", "Gino Latino", "Peter Vercammen" };
        }

    }
}
