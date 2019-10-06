using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.Views.ImageVw
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingIndicatorExternalImage : ContentPage
    {
        public LoadingIndicatorExternalImage()
        {
            InitializeComponent();

            //var imageSource = (UriImageSource) ImageSource.FromUri(new Uri("http://lorempixel.com/1920/1080/sports/7/"));
            //imageSource.CachingEnabled = false;
            var imageSource = new UriImageSource()
            {
                Uri = new Uri("http://lorempixel.com/1920/1024/sports/7/"),
                CachingEnabled = false
            };
            image.Source = imageSource;
        }

    }
}