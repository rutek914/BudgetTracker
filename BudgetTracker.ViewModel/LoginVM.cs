using BudgetTracker.Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net;
using System.Security.Principal;

namespace BudgetTracker.ViewModel
{
    public class LoginVM : NotifyBase
    {
        // DI
        private IUserRepository _userRepository;

        // wlasciwosci
        private string _username;
        public string Username
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }

        private SecureString _password;
        public SecureString Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        private bool _isViewVisible = true;
        public bool IsViewVisible
        {
            get => _isViewVisible;
            set => SetProperty(ref _isViewVisible, value);
        }


        // commands
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }
        public ICommand RememberPasswordCommand { get; }

        // constructor
        public LoginVM(IUserRepository userRepository)
        {
            LoginCommand = new RelayCommand(async _ => await ExecuteLoginCommand(), _ => CanExecuteLoginCommand());
            RecoverPasswordCommand = new RelayCommand(async p => await ExecuteRecoverPasswordCommand("", ""));
            _userRepository = userRepository;
        }



        private async Task ExecuteRecoverPasswordCommand(string username, string email)
        {
            throw new NotImplementedException();
        }

        private bool CanExecuteLoginCommand()
        {
            bool validData;
            if (string.IsNullOrWhiteSpace(Username) || Username.Length < 3 || Password == null || Password.Length < 3)
            {
                validData = false;
            }
            else 
            { 
                validData = true; 
            }
            return validData;
        }

        private async Task ExecuteLoginCommand()
        {
            var isValidUser = _userRepository.AuthenticateUser(new NetworkCredential(Username, Password));
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Username), null);
                IsViewVisible = false;
            }
            else
            {
                ErrorMessage = "Invalid username or password";
            }    
        }
    }
}
