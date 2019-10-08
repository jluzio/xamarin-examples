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
using Bumptech.Glide;

namespace BootcampTap.Droid.ViewHolders
{
    public class StoreViewHolder : RecyclerView.ViewHolder
    {
        private View _itemView;
        private TextView _storeName;
        private TextView _storeAddress;
        private ImageView _storeImage;

        public StoreViewHolder(View itemView) : base(itemView)
        {
            _itemView = itemView;
            _storeName = itemView.FindViewById<TextView>(Resource.Id.storeName);
            _storeAddress = itemView.FindViewById<TextView>(Resource.Id.storeAddress);
            _storeImage = itemView.FindViewById<ImageView>(Resource.Id.storeImage);
        }

        internal void SetupView(Store store)
        {
            _storeName.Text = store.Name;
            _storeAddress.Text = store.Address;

            if (!string.IsNullOrEmpty(store.PhotoUrl))
            {
                Glide.With(_itemView.Context).Load(store.PhotoUrl).Into(_storeImage);
            }
        }

        public void Recycle()
        {
            Glide.With(_itemView.Context).Clear(_storeImage);
        }
    }
}