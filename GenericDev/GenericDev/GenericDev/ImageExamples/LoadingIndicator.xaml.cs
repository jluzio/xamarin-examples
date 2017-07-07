using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.ImageExamples
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingIndicator : ContentPage
    {
        public LoadingIndicator()
        {
            InitializeComponent();
            loadData();
        }

        private async void loadData()
        {
            System.Diagnostics.Debug.WriteLine("loadData()...");
            loadingIndicator.IsRunning = true;
            loadingIndicator.IsVisible = true;
            await Task.Delay(10000);
            loadingIndicator.IsRunning = false;
            BackgroundColor = Color.Green;
            System.Diagnostics.Debug.WriteLine("loadData() done!");
        }
    }
}