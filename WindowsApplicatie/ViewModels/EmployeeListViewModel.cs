using System.Collections.ObjectModel;

namespace WindowsApplicatie.ViewModels
{
    class EmployeeListViewModel
    {


        public ObservableCollection<string> Employees { get; set; }

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
    }
    }
