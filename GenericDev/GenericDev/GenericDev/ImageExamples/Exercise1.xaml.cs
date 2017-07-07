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
    public partial class Exercise1 : ContentPage
    {
        private static String ImagePattern = "http://lorempixel.com/1920/1080/animals/{0}/";
        private static int MinImageIndex = 1;
        private static int MaxImageIndex = 10;

        private int ImageIndex = MinImageIndex;

        public Exercise1()
        {
            InitializeComponent();
            image.Source = GetImageSource();
        }

        private ImageSource GetImageSource()
        {
            string imageUri = String.Format(ImagePattern, ImageIndex);
            return new UriImageSource() {
                Uri = new Uri(imageUri),
                CachingEnabled = false
            };
        }

        private void previousBtn_Clicked(object sender, EventArgs e)
        {
            ImageIndex = Math.Max(ImageIndex - 1, MinImageIndex);
            image.Source = GetImageSource();
        }

        private void nextBtn_Clicked(object sender, EventArgs e)
        {
            ImageIndex = Math.Min(ImageIndex + 1, MaxImageIndex);
            image.Source = GetImageSource();
        }
    }
}