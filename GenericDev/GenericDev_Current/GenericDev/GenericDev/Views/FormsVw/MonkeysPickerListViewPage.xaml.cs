using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.Views.FormsVw
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MonkeysPickerListViewPage : ContentPage
	{
		public MonkeysPickerListViewPage ()
		{
			InitializeComponent ();

            listView.ItemsSource = new List<Monkey>
            {
                new Monkey { Name = "George"},
                new Monkey { Name = "Big Chief"},
                new Monkey { Name = "Ugabuga"}
            };
		}

        public ListView Monkeys
        {
            get { return listView; }
        }
	}
}