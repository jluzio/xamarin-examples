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
    public partial class Loading : ContentPage
    {
        public Loading()
        {
            InitializeComponent();

            var imageSource = (UriImageSource) ImageSource.FromUri(new Uri("todo-uri"));
            imageSource.CachingEnabled = false;

            image.Source = imageSource;
        }
    }
}