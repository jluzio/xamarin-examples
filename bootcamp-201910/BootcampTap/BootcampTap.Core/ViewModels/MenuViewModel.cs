using BootcampTap.Core.Services.Abstractions;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BootcampTap.Core.ViewModels
{
    public class MenuViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IAuthService _authService;

        private ICommand _openStoresCommand;
        public ICommand OpenStoresCommand =>
            _openStoresCommand ?? (_openStoresCommand = new RelayCommand(OpenStores));

        private ICommand _openStoreMapCommand;
        public ICommand OpenPromotionsCommand =>
            _openPromotionsCommand ?? (_openPromotionsCommand = new RelayCommand(OpenPromotions));

        private ICommand _openPromotionsCommand;
        public ICommand OpenStoreMapCommand =>
            _openStoreMapCommand ?? (_openStoreMapCommand = new RelayCommand(OpenStoreMap));

        private ICommand _logoutCommand;
        public ICommand LogoutCommand =>
            _logoutCommand ?? (_logoutCommand = new RelayCommand(Logout));

        public MenuViewModel(INavigationService navigationService, IAuthService authService)
        {
            _navigationService = navigationService;
            _authService = authService;
        }

        private void OpenStores()
        {
            _navigationService.NavigateTo(NavigationConstants.StoreListPage);
        }

        private void OpenPromotions()
        {
            _navigationService.NavigateTo(NavigationConstants.PromotionsPage);
        }

        private void OpenStoreMap()
        {
            _navigationService.NavigateTo(NavigationConstants.StoreMapPage);
        }

        private async void Logout()
        {
            await _authService.LogoutAsync();
            _navigationService.NavigateTo(NavigationConstants.LoginPage);
        }

    }
}
