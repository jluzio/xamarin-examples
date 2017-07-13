using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using GenericDev.Config;

namespace GenericDev
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var pageItemsSource = new List<Page>
            {
                new GenericDev.Views.MiscIndex(),
                new GenericDev.Views.BindingIndex(),
                new GenericDev.Views.StackLayoutIndex(),
                new GenericDev.Views.AbsoluteLayoutIndex(),
                new GenericDev.Views.GridIndex(),
                new GenericDev.Views.RelativeLayoutIndex(),
                new GenericDev.Views.ImageIndex(),
                new GenericDev.Views.ListViewIndex(),
                new GenericDev.Views.NavigationIndex(),
            };
            pages.ItemsSource = pageItemsSource;

            var systemInfo = DependencyService.Get<ISystemInfo>();
            if (systemInfo != null)
            {
                systemInfoLabel.Text = systemInfo.Title();
            }
            else
            {
                systemInfoLabel.Text = "<Undefined systemInfo.Title()>";
            }

        }

        async private void pages_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var page= e.SelectedItem as Page;
            await Navigation.PushAsync(page);
        }
    }
}
