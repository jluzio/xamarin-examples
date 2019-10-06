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
                new GenericDev.Views.CurrentVwIndex(),
                new GenericDev.Views.MiscVwIndex(),
                new GenericDev.Views.BindingVwIndex(),
                new GenericDev.Views.StackLayoutVwIndex(),
                new GenericDev.Views.AbsoluteLayoutVwIndex(),
                new GenericDev.Views.GridVwIndex(),
                new GenericDev.Views.RelativeLayoutVwIndex(),
                new GenericDev.Views.ImageVwIndex(),
                new GenericDev.Views.ListViewVwIndex(),
                new GenericDev.Views.NavigationVwIndex(),
                new GenericDev.Views.FormsVwIndex(),
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
            var page = e.SelectedItem as Page;
            if (page != null)
            {
                await Navigation.PushAsync(page);
                pages.SelectedItem = null;
            }
        }
    }
}
