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
    public class StoreListViewModel : ViewModelBase
    {
        private Services.Abstractions.IStoresService _storesService;
        private readonly IDialogService _dialogService;
        
        private bool _IsBusy;
        public bool IsBusy
        {
            get => _IsBusy;
            set
            {
                _IsBusy = value;
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

        public StoreListViewModel(Services.Abstractions.IStoresService storesService, IDialogService dialogService)
        {
            _storesService = storesService;
            _dialogService = dialogService;
        }

        private async Task RefreshList()
        {
            IsBusy = true;
            try
            {
                Stores = await _storesService.GetStoresAsync();
            }
            catch(Exception e)
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
