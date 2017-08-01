using GenericDev.Views.FormsVw.Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.Views.FormsVw.Exercise1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailPage : ContentPage
    {
        public event EventHandler<Contact> ContactAdd;
        public event EventHandler<Contact> ContactUpdate;

        public ContactDetailPage()
        {
            InitializeComponent();
        }


        async private void saveBtn_Clicked(object sender, EventArgs e)
        {
            var contact = BindingContext as Contact;
            if (String.IsNullOrEmpty(contact.FirstName) || String.IsNullOrEmpty(contact.LastName))
            {
                await DisplayAlert("Validation failed", "Please enter the name", "OK");
            }
            else
            {
                await Navigation.PopAsync();
                if (contact.Id == null)
                {
                    ContactAdd.Invoke(this, contact);
                } else
                {
                    ContactUpdate.Invoke(this, contact);
                }
            }
        }
    }
}