using BootcampTap.Core.Models;
using BootcampTap.Core.Services.Abstractions;
using BootcampTap.Core.Services.Implementations;
using BootcampTap.Core.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;


namespace BootcampTap.Core
{
    public class App
    {
        public static SimpleIoc Container { get; } = SimpleIoc.Default;

        private static INavigationService NavService => Container.GetInstance<INavigationService>();

        static App()
        {

        }

        public static void InitializeServices()
        {
            // Register ViewModels
            Container.Register<LoginViewModel>();
            Container.Register<MenuViewModel>();
            Container.Register<StoreListViewModel>();
            Container.Register<PromotionListViewModel>();
            Container.Register<StoreMapViewModel>();

            // Register Services
            Container.Register<IAuthService, AuthService>();
            Container.Register<IHttpRequestService, HttpRequestService>();
            Container.Register<Services.Abstractions.IStoresService, StoresService>();
            Container.Register<IPromotionsService, PromotionsService>();

        }

        public static void Start()
        {
            NavService.NavigateTo(NavigationConstants.LoginPage);
        }
    }
}
