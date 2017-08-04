using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GenericDev.Views.FormsVw.Exercise1.Models;

namespace GenericDev.Views.FormsVw.Exercise1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Exercise1 : ContentPage
	{
		public Exercise1 ()
		{
			InitializeComponent ();
		}

        private void startBtn_Clicked(object sender, EventArgs e)
        {
            //Application.Current.MainPage = new NavigationPage(new ContactListPage());
            Navigation.PushAsync(new ContactListPage());
        }
    }
}