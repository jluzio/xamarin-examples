using GenericDev.Views.FormsVw.Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.Views.FormsVw.Exercise1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactListPage : ContentPage
    {
        private int contactIdCount = 0;
        private ICollection<Contact> contacts;

        public ContactListPage()
        {
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            contacts = new ObservableCollection<Contact>
            {
                new Contact { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@server.org"},
                new Contact { Id = 2, FirstName = "Jane", LastName = "Moe", Email = "jone.moe@server.org"},
            };
            contactIdCount = contacts.Count;

            contactListView.ItemsSource = contacts;
        }

        private void addBtn_Clicked(object sender, EventArgs e)
        {
            OpenDetails(new Contact());
        }

        private void contactListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            //OpenDetails(e.SelectedItem as Contact);
        }

        private void contactRow_Tapped(object sender, EventArgs e)
        {
            OpenDetails(contactListView.SelectedItem as Contact);
        }


        async private void deleteBtn_Clicked(object sender, EventArgs e)
        {
            var contact = (sender as MenuItem).CommandParameter as Contact;
            bool confirmDelete = await DisplayAlert("Warning", $"Delete {contact.FirstName} {contact.LastName}?", "OK", "Cancel");
            if (confirmDelete)
            {
                contacts.Remove(contact);
            }
        }
        
        private void OpenDetails(Contact contact)
        {
            var contactToEdit = new Contact();
            copyData(contact, contactToEdit);

            var contactDetailsPage = new ContactDetailPage();
            contactDetailsPage.BindingContext = contactToEdit;
            contactDetailsPage.ContactAdd += (source, c) =>
            {
                contact = c;
                contact.Id = ++contactIdCount;
                contacts.Add(contact);
            };
            contactDetailsPage.ContactUpdate += (source, c) =>
            {
                copyData(c, contact);
            };

            Navigation.PushAsync(contactDetailsPage);
        }

        private void copyData(Contact from, Contact to)
        {
            to.Id = from.Id;
            to.FirstName = from.FirstName;
            to.LastName = from.LastName;
            to.Phone = from.Phone;
            to.Email = from.Email;
            to.Blocked = from.Blocked;
        }

    }
}