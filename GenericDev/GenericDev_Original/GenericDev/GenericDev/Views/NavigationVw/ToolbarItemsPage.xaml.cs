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
    public partial class ToolbarItemsPage : ContentPage
    {
        public ToolbarItemsPage()
        {
            InitializeComponent();
        }

        private void toolbarItem_Activated(object sender, EventArgs e)
        {
            var toolbarItem = sender as ToolbarItem;
            DisplayAlert("ToolbarItems", toolbarItem.Text, "OK");
        }

    }
}