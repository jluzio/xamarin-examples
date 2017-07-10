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
    public partial class EmbeddedImage : ContentPage
    {
        public EmbeddedImage()
        {
            InitializeComponent();
        }
    }
}