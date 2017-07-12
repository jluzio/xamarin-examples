using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.Binding
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Index : ContentPage
	{
		public Index ()
		{
			InitializeComponent ();
		}

        private async void OnBackwardsBindings(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BackwardsBindings());
        }
    }
}