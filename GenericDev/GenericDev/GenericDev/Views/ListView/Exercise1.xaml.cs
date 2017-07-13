using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using GenericDev.Views.ListView.Models;
using GenericDev.Views.ListView.Services;

namespace GenericDev.Views.ListView
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Exercise1 : ContentPage
    {
        private ISearchService SearchService;
        private String SearchString;

        public Exercise1()
        {
            InitializeComponent();
            SearchService = DependencyService.Get<ISearchService>();
            PopulateView();
        }

        private void listView_Refreshing(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("listView_Refreshing");
            SearchService.Reload();
            PopulateView(SearchString);
            listView.EndRefresh();
        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("searchBar_TextChanged: {0}", e.NewTextValue));
            PopulateView(e.NewTextValue);
            SearchString = e.NewTextValue;
        }

        private void PopulateView(String filter = null)
        {
            var results = SearchService.GetSearches(filter);

            var recentSearchGroup = new SearchGroup("Recent Searches");
            recentSearchGroup.AddRange(results);
            
            var searchGroups = new List<SearchGroup>();
            searchGroups.Add(recentSearchGroup);

            listView.ItemsSource = searchGroups;
        }

        private void Delete_Clicked(object sender, EventArgs e)
        {
            var search = (sender as MenuItem).CommandParameter as Search;
            SearchService.DeleteSearch(search.Id);
            PopulateView(SearchString);
        }

        private void listView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var search = e.SelectedItem as Search;
            DisplayAlert("Previous Search", $"Location: {search.Location}", "OK");
        }
    }
}