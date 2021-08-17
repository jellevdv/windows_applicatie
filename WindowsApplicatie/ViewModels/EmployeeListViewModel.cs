using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace WindowsApplicatie.ViewModels
{
    class EmployeeListViewModel
    {
        //command
        public ICommand AddEmployeeCommand => new Command(AddEmployee);

        //obersavble list 
        public ObservableCollection<string> Employees { get; set; }

        //Binds itself to the textbox in the view itself
        public string EmployeeName { get; set; }

        public EmployeeListViewModel()
        {
            Employees = new ObservableCollection<string>
            {
                "Jelle Vandevyvere",
                "Kadir Olmez",
                "Peter Vercammen",
                "Gino Latino"
            };
        }

        public void AddEmployee()
        {
            Employees.Add(EmployeeName);
        }
    }
}
