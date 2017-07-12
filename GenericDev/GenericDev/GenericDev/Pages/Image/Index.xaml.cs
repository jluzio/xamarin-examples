using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.Image
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Index : ContentPage
    {
        public Index()
        {
            InitializeComponent();
        }

        async private void OnLoadingIndicatorButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoadingIndicator());
        }

        async private void OnUriImageButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LoadingIndicatorExternalImage());
        }

        async private void OnEmbeddedImageButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new EmbeddedImage());
        }

        async private void OnLocalImageButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LocalImage());
        }

        async private void OnImageCirclePluginButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImageCirclePlugin());
        }

        async private void OnExercise1ButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Exercise1());
        }

    }
}