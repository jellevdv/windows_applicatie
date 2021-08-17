using System;
using System.Windows.Input;

namespace WindowsApplicatie
{
    public class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        private Action<object> execute;
        private Func<object, bool> canExecute = (_) => true;

        public RelayCommand(Action<object> action)
        {
            execute = action;
        }

        public RelayCommand(Action<object> action, Func<object, bool> test)
        {
            execute = action;
            canExecute = test;
        }

        public RelayCommand(Action addEmployee)
        {
        }

        public bool CanExecute(object parameter)
        {
            return canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
