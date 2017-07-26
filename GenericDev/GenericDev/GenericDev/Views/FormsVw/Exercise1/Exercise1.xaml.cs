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

            contacts.ItemsSource = new List<Contact>
            {
                new Contact { FirstName = "John", LastName = "Doe", Email = "john.doe@server.org"},
                new Contact { FirstName = "Jane", LastName = "Moe", Email = "jone.moe@server.org"},
            };
		}
	}
}