using System.Collections.ObjectModel;
using System.Linq;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using WindowsApplicatie.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace WindowsApplicatie.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TestPage : Page
    {
        ObservableCollection<listboxData> lst = new ObservableCollection<listboxData>();

        public TestPage()
        {
            this.InitializeComponent();
            //lbDetails.ItemsSource = lst;
            this.DataContext = new ItemPageViewModel();
        }

        
        private void btnDetails_Click_1(object sender, RoutedEventArgs e)
        {
            lst.Add(new listboxData("Textblock" + lst.Count, new SolidColorBrush(Colors.YellowGreen)));

        }

    }

    public class listboxData
    {
        public string text { get; set; }
        public SolidColorBrush bg { get; set; }

        public listboxData(string text, SolidColorBrush bg)
        {
            this.text = text;
            this.bg = bg;
        }
    }

}
