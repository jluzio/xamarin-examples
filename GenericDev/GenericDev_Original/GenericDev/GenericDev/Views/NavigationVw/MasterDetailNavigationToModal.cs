using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GenericDev.Views.NavigationVw
{
    public class MasterDetailNavigateToModal : ItemListPage
    {
        public MasterDetailNavigateToModal() : base()
        {
            Title = "Master Detail - Navigation to Modal";
        }

        async public override void items_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushModalAsync(new MasterDetailNavigateToModalItemDetailPage());
        }

        public override void items_ItemTapped(object sender, ItemTappedEventArgs e)
        {
        }
    }

    public class MasterDetailNavigateToModalItemDetailPage : ItemDetailPage
    {
        public MasterDetailNavigateToModalItemDetailPage() : base()
        {
        }

        async protected override void back_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}