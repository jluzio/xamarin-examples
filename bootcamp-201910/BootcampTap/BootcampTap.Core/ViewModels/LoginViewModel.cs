using AsyncAwaitBestPractices.MVVM;
using BootcampTap.Core.Services.Abstractions;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BootcampTap.Core.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly IAuthService _authService;
        private readonly IDialogService _dialogService;
        private readonly INavigationService _navigationService;
        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                RaisePropertyChanged(nameof(Username));
            }
        }

        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                RaisePropertyChanged(nameof(Password));
                ((AsyncCommand)LoginCommand).RaiseCanExecuteChanged();
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                RaisePropertyChanged(nameof(IsBusy));
                ((AsyncCommand)LoginCommand).RaiseCanExecuteChanged();
            }
        }

        private IAsyncCommand _loginCommmand;
        public IAsyncCommand LoginCommand => 
            _loginCommmand ?? (_loginCommmand = new AsyncCommand(LoginAsync, CanLogin));

        private ICommand _setUsernameCommand;
        public ICommand SetUsernameCommand =>
            _setUsernameCommand ?? (_setUsernameCommand = new RelayCommand<string>(SetUsername));

        private ICommand _setPasswordCommand;
        public ICommand SetPasswordCommand =>
            _setPasswordCommand ?? (_setPasswordCommand = new RelayCommand<string>(SetPassword));

        public LoginViewModel(IAuthService authService, IDialogService dialogService, INavigationService navigationService)
        {
            _authService = authService;
            _dialogService = dialogService;
            _navigationService = navigationService;
        }

        private async Task LoginAsync()
        {
            IsBusy = true;
            try
            {
                //await _authService.LoginAsync(_username, _password);
                _navigationService.NavigateTo(NavigationConstants.MenuPage);
            } 
            catch (Exception e)
            {
                await _dialogService.ShowMessage($"Ocorreu um erro {e.Message}", "Erro");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private bool CanLogin(object @object)
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password) && !IsBusy;
        }

        private void SetUsername(string username)
        {
            _username = username;
            ((AsyncCommand)LoginCommand).RaiseCanExecuteChanged();
        }

        private void SetPassword(string password)
        {
            _password = password;
            ((AsyncCommand)LoginCommand).RaiseCanExecuteChanged();
        }
    }
}
