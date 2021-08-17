using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace WindowsApplicatie.ViewModels
{
    class EmployeeListViewModel
    {
        //relaycommand
        public ICommand AddEmployeeCommand { get; }
        //obersavble list 
        public ObservableCollection<string> Employees { get; set; }

        //Binds itself to the textbox in the view itself
        public string EmployeeName { get; set; }

        public EmployeeListViewModel()
        {
            AddEmployeeCommand = new RelayCommand(AddEmployee);
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
