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
using BootcampTap.Core.ViewModels;
using BootcampTap.Droid.Adapters;
using GalaSoft.MvvmLight.Views;

namespace BootcampTap.Droid.Activities
{
    [Activity(Label = "PromotionListActivity")]
    public class PromotionListActivity : ActivityBase
    {
        private PromotionListViewModel _viewModel;
        private SwipeRefreshLayout _refreshLayout;
        private RecyclerView _recyclerView;
        private Button _createButton;
        private ProgressBar _progressBar;
        private PromotionListAdapter _listAdapter;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_promotion_list);

            _viewModel = App.Container.GetInstance<PromotionListViewModel>();

            _refreshLayout = FindViewById<SwipeRefreshLayout>(Resource.Id.SwipeRefreshLayout);
            _recyclerView = FindViewById<RecyclerView>(Resource.Id.StoreRecyclerView);
            _progressBar = FindViewById<ProgressBar>(Resource.Id.ProgressBar);

            _listAdapter = new PromotionListAdapter(_viewModel);
            _recyclerView.SetAdapter(_listAdapter);
            _recyclerView.SetLayoutManager(new LinearLayoutManager(this));

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
            if (e.PropertyName == nameof(_viewModel.Promotions))
                _listAdapter.NotifyDataSetChanged();
            else if (e.PropertyName == nameof(_viewModel.IsBusy))
                _progressBar.Visibility = _viewModel.IsBusy ? ViewStates.Visible : ViewStates.Invisible;
        }
    }
}
