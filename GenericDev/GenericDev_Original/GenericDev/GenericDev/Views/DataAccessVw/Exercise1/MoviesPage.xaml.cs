using GenericDev.Views.DataAccessVw.Exercise1.Models;
using GenericDev.Views.DataAccessVw.Exercise1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.Views.DataAccessVw.Exercise1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesPage : ContentPage
    {
        private MovieService movieService = new MovieService();
        private ObservableCollection<Movie> movies;

        public static readonly BindableProperty IsSearchingProperty =
                    BindableProperty.Create("IsSearching", typeof(bool), typeof(MoviesPage), false);

        public bool IsSearching
        {
            get { return (bool)GetValue(IsSearchingProperty); }
            set { SetValue(IsSearchingProperty, value); }
        }

        public MoviesPage()
        {
            InitializeComponent();

            searchBar.SearchCommand = new Command(() => { Search(searchBar.Text); });
        }

        public async void Search(string actor)
        {
            var searchActor = actor?.Trim();
            if (searchActor?.Length >= 5 && !IsSearching)
            {
                try
                {
                    IsSearching = true;
                    var loadedMovies = await movieService.FindMoviesByActor(searchActor);
                    movies = new ObservableCollection<Movie>(loadedMovies);
                    moviesListView.ItemsSource = movies;
                    moviesListView.IsVisible = movies.Any();
                    noResultsMessage.IsVisible = !movies.Any();
                }
                catch (Exception e)
                {
                    await DisplayAlert("Error", $"Search returned error: {e.Message}", "OK");
                }
                finally
                {
                    IsSearching = false;
                }
            }
        }

        private void searchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            Search(e.NewTextValue);
        }

        private async void moviesListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var movie = e.SelectedItem as Movie;
            if (movie != null)
            {
                var movieDetailsPage = new MovieDetailsPage { BindingContext = movie };
                await Navigation.PushAsync(movieDetailsPage);
                moviesListView.SelectedItem = null;
            }
        }
    }
}