using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.BindingExamples
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExamplesPage : ContentPage
	{
		public ExamplesPage ()
		{
			InitializeComponent ();
		}

        private async void OnBackwardsBindings(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new BackwardsBindings());
        }
    }
}