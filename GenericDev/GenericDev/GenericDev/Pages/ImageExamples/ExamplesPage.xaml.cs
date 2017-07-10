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
    public partial class ExamplesPage : ContentPage
    {
        public ExamplesPage()
        {
            InitializeComponent();
        }

        async private void OnLoadingIndicatorButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoadingIndicator());
        }

        async private void OnUriImageButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoadingIndicatorExternalImage());
        }

        async private void OnEmbeddedImageButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new EmbeddedImage());
        }

        async private void OnLocalImageButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LocalImage());
        }

        async private void OnImageCirclePluginButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ImageCirclePlugin());
        }

        async private void OnExercise1ButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Exercise1());
        }

    }
}