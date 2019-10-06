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
	public partial class TableViewPage : ContentPage
	{
		public TableViewPage ()
		{
			InitializeComponent ();
		}

        private void monkeyCell_Tapped(object sender, EventArgs e)
        {
            var page = new MonkeysPickerListViewPage();
            page.Monkeys.ItemSelected += (source, args) =>
            {
                monkeyLabel.Text = (args.SelectedItem as Monkey).Name;
                Navigation.PopAsync();
            };
            Navigation.PushAsync(page);

        }
    }
}