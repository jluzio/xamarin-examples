using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.Views.NavigationVw
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Popups : ContentPage
    {
        public Popups()
        {
            InitializeComponent();
        }

        async private void displayAlertBtn_Clicked(object sender, EventArgs e)
        {
            var okPressed = await DisplayAlert("Popups", "Alert", "OK", "Cancel");
            await DisplayAlert("Popups", "Pressed ok? " + okPressed, "Done");
        }

        async private void displayActionSheetBtn_Clicked(object sender, EventArgs e)
        {
            var actionSelected = await DisplayActionSheet("Action Sheet", "Cancel", "DESTROY", "Copy", "Share", "Drink Tea");
            await DisplayAlert("Popups", "Selected action:  " + actionSelected, "Done");
        }
    }
}