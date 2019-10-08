using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using BootcampTap.Core;
using BootcampTap.Droid.Activities;
using GalaSoft.MvvmLight.Views;

namespace BootcampTap.Droid
{
    [Application(Debuggable =true, Theme = "@style/AppTheme")]
    public class MainApplication : Application
    {
        protected MainApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {

        }

        public override void OnCreate()
        {
            base.OnCreate();

            App.InitializeServices();
            RegisterPlatformServices();
            RegisterNavigation();
        }

        private void RegisterPlatformServices()
        {
            App.Container.Register<IDialogService, DialogService>();
        }

        private void RegisterNavigation()
        {
            var nav = new NavigationService();
            nav.Configure(NavigationConstants.LoginPage, typeof(LoginActivity));
            nav.Configure(NavigationConstants.MenuPage, typeof(MenuActivity));
            nav.Configure(NavigationConstants.StoreListPage, typeof(StoreListActivity));
            nav.Configure(NavigationConstants.PromotionsPage, typeof(PromotionListActivity));
            nav.Configure(NavigationConstants.StoreMapPage, typeof(StoreMapActivity));

            App.Container.Register<INavigationService>(() => nav);
        }
    }
}