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
    public class PromotionListViewModel : ViewModelBase
    {
        private readonly IPromotionsService _promotionsService;
        private readonly IDialogService _dialogService;

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

        private List<Promotion> _promotions;
        public List<Promotion> Promotions
        {
            get => _promotions;
            set
            {
                _promotions = value;
                RaisePropertyChanged(nameof(Promotions));
            }
        }

        private ICommand _refreshListCommand;
        public ICommand RefreshListCommand =>
            (_refreshListCommand ?? (_refreshListCommand = new AsyncCommand(RefreshList)));

        public PromotionListViewModel(IPromotionsService promotionsService, IDialogService dialogService)
        {
            this._promotionsService = promotionsService;
            this._dialogService = dialogService;
        }

        private async Task RefreshList()
        {
            IsBusy = true;
            try
            {
                Promotions = await _promotionsService.GetPromotionsAsync();
            }
            catch(Exception e)
            {
                await _dialogService.ShowMessage($"Error details: {e.Message}", "Error");
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
