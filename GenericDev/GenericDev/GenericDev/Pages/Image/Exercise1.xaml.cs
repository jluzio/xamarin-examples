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
            System.Diagnostics.Debug.WriteLine("nextBtn_Clicked");
            ImageIndex = Math.Min(ImageIndex + 1, MaxImageIndex);
            image.Source = GetImageSource();
        }

        /*
        private void image_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            // Fix issues with UWP until bug is fixed in Xamarin 2.3.5 (?)
            if (String.Equals(Device.RuntimePlatform, Device.Windows)) {
                System.Diagnostics.Debug.WriteLine(String.Format("image_PropertyChanging {0}", e.PropertyName));
                if (String.Equals(e.PropertyName, "IsLoading") && Device.RuntimePlatform == Device.Windows)
                {
                    loadingIndicator.IsRunning = true;
                    loadingIndicator.IsVisible = true;
                }
            }
        }

        private void image_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            // Fix issues with UWP until bug is fixed in Xamarin 2.3.5 (?)
            if (String.Equals(Device.RuntimePlatform, Device.Windows))
            {
                System.Diagnostics.Debug.WriteLine(String.Format("image_PropertyChanged {0}", e.PropertyName));
                if (String.Equals(e.PropertyName, "IsLoading"))
                {
                    loadingIndicator.IsRunning = false;
                    loadingIndicator.IsVisible = false;
                }
            }
        }
    */
    }
}