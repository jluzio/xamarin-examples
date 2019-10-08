using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using BootcampTap.Core;
using BootcampTap.Core.Models;
using BootcampTap.Core.ViewModels;
using BootcampTap.Droid.Adapters;
using GalaSoft.MvvmLight.Views;

namespace BootcampTap.Droid.Activities
{
    [Activity(Label = "StoreListActivity")]
    public class StoreListActivity : ActivityBase
    {
        private StoreListViewModel _viewModel;
        private SwipeRefreshLayout _refreshLayout;
        private RecyclerView _storeRecyclerView;
        private Button _createButton;
        private ProgressBar _progressBar;
        private StoreListAdapter _storeListAdapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_store_list);

            _viewModel = App.Container.GetInstance<StoreListViewModel>();

            _refreshLayout = FindViewById<SwipeRefreshLayout>(Resource.Id.SwipeRefreshLayout);
            _storeRecyclerView = FindViewById<RecyclerView>(Resource.Id.StoreRecyclerView);
            _createButton = FindViewById<Button>(Resource.Id.CreateButton);
            _progressBar = FindViewById<ProgressBar>(Resource.Id.ProgressBar);

            _storeListAdapter = new StoreListAdapter(_viewModel);
            _storeRecyclerView.SetAdapter(_storeListAdapter);
            _storeRecyclerView.SetLayoutManager(new LinearLayoutManager(this));

            _viewModel.PropertyChanged += _viewModel_PropertyChanged;

            _refreshLayout.Refresh += _swipeRefreshLayout_Refresh;

            _viewModel.RefreshListCommand?.Execute(null);
        }

        private void _swipeRefreshLayout_Refresh(object sender, EventArgs e)
        {
            _viewModel.RefreshListCommand?.Execute(null);
            _refreshLayout.Refreshing = false;
        }

        private void _viewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_viewModel.Stores))
            {
                _storeListAdapter.NotifyDataSetChanged();
            }
            else if (e.PropertyName == nameof(_viewModel.IsBusy))
            {
                _progressBar.Visibility = _viewModel.IsBusy ? ViewStates.Visible : ViewStates.Invisible;
            }
        }
    }
}