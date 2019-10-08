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
    public class PromotionViewHolder : RecyclerView.ViewHolder
    {
        private View _itemView;
        private TextView _promotionProduct;
        private TextView _promotionDiscount;

        public PromotionViewHolder(View itemView) : base(itemView)
        {
            _itemView = itemView;
            _promotionProduct = itemView.FindViewById<TextView>(Resource.Id.promotionProduct);
            _promotionDiscount = itemView.FindViewById<TextView>(Resource.Id.promotionDiscount);
        }

        internal void SetupView(Promotion promotion)
        {
            _promotionProduct.Text = promotion.Product;
            _promotionDiscount.Text = promotion.Discount.ToString();
        }

        public void Recycle()
        {
        }
    }
}