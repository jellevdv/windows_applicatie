using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using WindowsApplicatie_NetteVersie.Models;
using WindowsApplicatie_NetteVersie.Views;
using Xamarin.Forms;

namespace WindowsApplicatie_NetteVersie.ViewModels
{
    class AuthViewModel : INotifyPropertyChanged
    {
        private AuthService _authService;
        private string _passwError;
        private string _emailError;

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand TryLogin => new Command(Login);
        public ICommand TryRegister => new Command(Register);

        //public ObservableCollection<Holiday> Holidays { get; set; }

        //public Holiday SelectedHoliday { get; set; }

        //public string HolidayName { get; set; }
        //public string HolidayDestination { get; set; }
        //public string HolidayDescription { get; set; }
        //public DateTime HolidayDepartureDate { get; set; }

        public string Email { get; set; }
        public string EmailError
        {
            get
            {
                return _emailError;
            }
            set
            {
                _emailError = value;
                this.OnPropertyChanged();
            }
        }

        public string Passw { get; set; }
        public string PasswError
        {
            get
            {
                return _passwError;
            }
            set
            {
                this._passwError = value;
                this.OnPropertyChanged();
            }
        }

        public string AppError { get; set; }

        public AuthViewModel()
        {
            AuthService auth = new AuthService();
            _authService = auth;
        }

        public async void Login()
        {
            (User u, CustomError c) = await _authService.Login(Email, Passw);
            if (c.Message != null)
            {

                EmailError = "";
                PasswError = "";

                switch (c.Scope)
                {
                    case "email":
                        EmailError = c.Message;
                        break;
                    case "password":
                        PasswError = c.Message;
                        break;
                    case "app":
                        AppError = c.Message;
                        ErrorDialog er = new ErrorDialog();
                        er.SetErrorMessage("Something went wrong... Please contact support for assistance!", c.Message);
                        await er.ShowAsync();
                        break;
                    default:
                        break;
                }

            }


        }

        public void Register()
        {

        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
