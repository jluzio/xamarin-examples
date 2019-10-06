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
    public abstract partial class ItemListPage : ContentPage
    {
        public ItemListPage()
        {
            InitializeComponent();

            items.ItemsSource = new List<Item>
            {
                new Item { Name = "Item 1" },
                new Item { Name = "Item 2" },
                new Item { Name = "Item 3" },
            };
        }

        public abstract void items_ItemSelected(object sender, SelectedItemChangedEventArgs e);

        public abstract void items_ItemTapped(object sender, ItemTappedEventArgs e);

    }
}