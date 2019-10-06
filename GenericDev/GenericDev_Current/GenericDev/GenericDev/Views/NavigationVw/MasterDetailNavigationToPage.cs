using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace GenericDev.Views.NavigationVw
{
    public class MasterDetailNavigateToPage : ItemListPage
    {
        public MasterDetailNavigateToPage() : base()
        {
            Title = "Master Detail - Navigation to Page";
        }

        async public override void items_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new MasterDetailNavigateToPageItemDetailPage());
        }

        public override void items_ItemTapped(object sender, ItemTappedEventArgs e)
        {
        }
    }

    public class MasterDetailNavigateToPageItemDetailPage : ItemDetailPage
    {
        public MasterDetailNavigateToPageItemDetailPage() : base()
        {
        }
    }
}