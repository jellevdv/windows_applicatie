using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace WindowsApplicatie.ViewModels
{
    class EmployeeListViewModel
    {
        //command to add an employee
        public ICommand AddEmployeeCommand => new Command(AddEmployee);

        //command to remove an employee
        public ICommand RemoveEmployeeCommand => new Command(RemoveEmployee);



        //obersavble list 
        public ObservableCollection<string> Employees { get; set; }

        //Binds itself to the textbox in the view itself
        public string EmployeeName { get; set; }

        public string SelectedEmployee { get; set; }

        public EmployeeListViewModel()
        {
          //  AddEmployeeCommand = new RelayCommand(AddEmployee);

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
            Console.WriteLine("AddEmployeeCommandCLicked");
            Employees.Add(EmployeeName);
        }

        public void RemoveEmployee()
        {
            Employees.Remove(SelectedEmployee);
        }

    }
}
