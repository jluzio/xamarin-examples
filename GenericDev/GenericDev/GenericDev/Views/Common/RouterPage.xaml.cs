using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.Views.Common
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RouterPage : ContentPage
    {
        public global::Xamarin.Forms.ListView Pages
        {
            get
            {
                return pages;
            }
        }

        public RouterPage()
        {
            InitializeComponent();
        }

        public RouterPage(List<Page> pagesItemsSource) : this()
        {
            pages.ItemsSource = pagesItemsSource;
        }

        async private void pages_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var page = e.SelectedItem as Page;
            if (page != null)
            {
                await Navigation.PushAsync(page);
                pages.SelectedItem = null;
            }
        }
    }
}