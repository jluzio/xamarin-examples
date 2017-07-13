using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.Views.Navigation
{
    public class Item
    {
        public String Name { get; set; }
        public String Page { get; set; }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetail : MasterDetailPage
    {
        public MasterDetail()
        {
            InitializeComponent();

            items.ItemsSource = new List<Item>
            {
                new Item { Name = "Item 1" },
                new Item { Name = "Item 2" },
                new Item { Name = "Item 3" },
            };
        }

        private void items_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Item;
            Detail = new ItemDetail { BindingContext = item };

        }

        private void items_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            IsPresented = false;
        }

    }
}