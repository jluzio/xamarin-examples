using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.Views.CommonVw
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RouterPage : ContentPage
    {
        private ObservableCollection<Page> pages;

        public ObservableCollection<Page> Pages
        {
            get { return pages; }
            set
            {
                pages = value;
                pages.ForEach(page => page.Title = page.Title ?? page.GetType().Name);
                pagesListView.ItemsSource = pages;
            }
        }

        public RouterPage()
        {
            InitializeComponent();
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        async private void pages_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var page = e.SelectedItem as Page;
            if (page != null)
            {
                await Navigation.PushAsync(page);
                pagesListView.SelectedItem = null;
            }
        }
    }
}