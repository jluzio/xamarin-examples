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
using BootcampTap.Core.ViewModels;
using GalaSoft.MvvmLight.Views;

namespace BootcampTap.Droid.Activities
{
    [Activity(Label = "MenuActivity")]
    public class MenuActivity : ActivityBase
    {
        private MenuViewModel _viewModel;
        private Button _openStoresButton;
        private Button _openPromotionsButton;
        private Button _openStoreMapButton;
        private Button _logoutButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_menu);

            _viewModel = App.Container.GetInstance<MenuViewModel>();

            _openStoresButton = FindViewById<Button>(Resource.Id.OpenStoresButton);
            _openPromotionsButton = FindViewById<Button>(Resource.Id.OpenPromotionsButton);
            _openStoreMapButton = FindViewById<Button>(Resource.Id.OpenStoreMapButton);
            _logoutButton = FindViewById<Button>(Resource.Id.LogoutButton);

            _openStoresButton.Click += _openStoresButton_Click;
            _openPromotionsButton.Click += _openPromotionsButton_Click;
            _openStoreMapButton.Click += _openStoreMapButton_Click;
            _logoutButton.Click += _logoutButton_Click;
        }

        private void _logoutButton_Click(object sender, EventArgs e)
        {
            _viewModel.LogoutCommand.Execute(null);
        }

        private void _openStoreMapButton_Click(object sender, EventArgs e)
        {
            _viewModel.OpenStoreMapCommand.Execute(null);
        }

        private void _openPromotionsButton_Click(object sender, EventArgs e)
        {
            _viewModel.OpenPromotionsCommand.Execute(null);
        }

        private void _openStoresButton_Click(object sender, EventArgs e)
        {
            _viewModel.OpenStoresCommand.Execute(null);
        }
    }
}