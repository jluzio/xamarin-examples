using AsyncAwaitBestPractices.MVVM;
using BootcampTap.Core.Models;
using BootcampTap.Core.Services.Abstractions;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BootcampTap.Core.ViewModels
{
    public class StoreMapViewModel : ViewModelBase
    {
        public StoreMapViewModel(IStoresService storesService, IDialogService dialogService)
        {
            _dialogService = dialogService;
            _storesService = storesService;
        }

        private readonly IDialogService _dialogService;
        private readonly Services.Abstractions.IStoresService _storesService;

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                RaisePropertyChanged(nameof(IsBusy));
            }
        }

        private List<Store> _stores;
        public List<Store> Stores
        {
            get => _stores;
            set
            {
                _stores = value;
                RaisePropertyChanged(nameof(Stores));
            }
        }

        private ICommand _refreshListCommand;
        public ICommand RefreshListCommand =>
            _refreshListCommand ?? (_refreshListCommand = new AsyncCommand(RefreshList));

        private async Task RefreshList()
        {
            IsBusy = true;
            try
            {
                Stores = await _storesService.GetStoresAsync();
            }
            catch (Exception e)
            {
                await _dialogService.ShowMessage($"Erro a obter os dados: {e.Message}", "Erro");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
