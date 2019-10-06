using GenericDev.Views.NavigationVw.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.Views.NavigationVw
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetail : MasterDetailPage
    {
        public MasterDetail(bool detailNeedsNavigation = false)
        {
            InitializeComponent();
            var master = (Master as MasterDetailItemListPage);
            master.DetailNeedsNavigation = detailNeedsNavigation;
        }
    }

    public class MasterDetailItemListPage : ItemListPage
    {
        public bool DetailNeedsNavigation { get; set; }

        public MasterDetailItemListPage() : base()
        {
        }

        public override void items_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Item;
            var masterDetailPage = GetParentMasterDetailPage();
            var itemDetailPage = new MasterDetailItemDetailPage
            {
                BindingContext = item,
                ParentMasterDetailPage = masterDetailPage
            };
            var detail = DetailNeedsNavigation
                ? (Page) new NavigationPage(itemDetailPage)
                : (Page) itemDetailPage;
            masterDetailPage.Detail = detail;
        }

        public override void items_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            GetParentMasterDetailPage().IsPresented = false;
        }

        public MasterDetailPage GetParentMasterDetailPage()
        {
            return Parent as MasterDetailPage;
        }

    }

    public class MasterDetailItemDetailPage : ItemDetailPage
    {
        public MasterDetailPage ParentMasterDetailPage { get; set; }

        public MasterDetailItemDetailPage() : base()
        {
        }

        protected override void back_Clicked(object sender, EventArgs e)
        {
            ParentMasterDetailPage.IsPresented = true;
            //base.back_Clicked(sender, e);
        }

    }
}