using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.Views.MiscVw
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DynamicResourcesPage : ContentPage
    {
        public DynamicResourcesPage()
        {
            InitializeComponent();
            Resources = new ResourceDictionary();
            Resources["bgColor"] = "Red";
        }

        private void changeStyleBtn_Clicked(object sender, EventArgs e)
        {
            Resources["bgColor"] = ("Red".Equals(Resources["bgColor"]) ? "Blue": "Red");
        }
    }
}