using GenericDev.Views.DataAccessVw.Exercise1.Models;
using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GenericDev.Views.DataAccessVw.Exercise1.Services
{
    public class MovieService
    {
        private const string findMovieByActorUrlPattern = "http://netflixroulette.net/api/api.php?actor={0}";
        private const string getMovieDetailsUrlPattern = "http://netflixroulette.net/api/api.php?title={0}";
        private HttpClient client;

        public MovieService()
        {
            client = new HttpClient(new NativeMessageHandler());
        }

        public async Task<IEnumerable<Movie>> FindMoviesByActor(string actor)
        {
            var queryUrl = String.Format(findMovieByActorUrlPattern, actor);
            var response = await client.GetAsync(queryUrl);

            List<Movie> movies = null;
            if (response.StatusCode == HttpStatusCode.NotFound) {
                movies = new List<Movie>();
            } else {
                var content = await response.Content.ReadAsStringAsync();
                movies = JsonConvert.DeserializeObject<List<Movie>>(content);
            }
            return movies;
        }

        public async Task<Movie> GetMovie(string title)
        {
            var queryUrl = String.Format(getMovieDetailsUrlPattern, title);
            var response = await client.GetAsync(queryUrl);

            Movie movie = null;
            if (response.StatusCode != HttpStatusCode.NotFound)
            {
                var content = await response.Content.ReadAsStringAsync();
                movie = JsonConvert.DeserializeObject<Movie>(content);
            }
            return movie;
        }
    }
}
