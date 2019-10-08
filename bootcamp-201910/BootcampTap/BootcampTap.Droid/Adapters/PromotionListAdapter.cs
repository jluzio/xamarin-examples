using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using BootcampTap.Core.Models;
using BootcampTap.Core.Services.Abstractions;
using BootcampTap.Core.ViewModels;
using BootcampTap.Droid.ViewHolders;
using Java.Lang;

namespace BootcampTap.Droid.Adapters
{
    public class PromotionListAdapter : RecyclerView.Adapter
    {
        private PromotionListViewModel _viewModel;

        public PromotionListAdapter(PromotionListViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override int ItemCount => _viewModel.Promotions?.Count ?? 0;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (holder is PromotionViewHolder vh)
            {
                var store = _viewModel.Promotions[position];
                vh.SetupView(store);
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater layoutInflater = LayoutInflater.From(parent.Context);
            View itemView = layoutInflater.Inflate(Resource.Layout.view_holder_promotion, parent, false);
            var vh = new PromotionViewHolder(itemView);
            return vh;
        }

        public override void OnViewRecycled(Java.Lang.Object holder)
        {
            if (holder is PromotionViewHolder vh)
                vh.Recycle();
        }
    }
}