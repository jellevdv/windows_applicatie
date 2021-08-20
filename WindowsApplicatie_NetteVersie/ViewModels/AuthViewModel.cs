using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using WindowsApplicatie_NetteVersie.Models;
using WindowsApplicatie_NetteVersie.Views;

namespace WindowsApplicatie_NetteVersie.ViewModels
{
    class AuthViewModel : INotifyPropertyChanged
    {
        private string _passwError;
        private string _emailError;

        public event PropertyChangedEventHandler PropertyChanged;

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

        public string PasswConfirm { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        public AuthViewModel()
        {
        }

        public async Task<User> Login()
        {
            (User u, CustomError c) = await AuthService.Login(Email, Passw);
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
            return u;
        }


        public async Task<(User, CustomError)> Register(DateTimeOffset date)
        {
            (User u, CustomError c) = await AuthService.Register(Email, FirstName, LastName, Phone, Passw, PasswConfirm, date);            

            return (u, c);
        }

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
