using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDev.Views.DataAccessVw.Exercise1.Models
{
    /*
Movie:
  {	
	"unit": 636,
	"show_id": 643557,
	"show_title": "It Could Happen to You",
	"release_year": "1994",
	"rating": "3.4",
	"category": "Comedies",
	"show_cast": "Nicolas Cage, Bridget Fonda, ...",
	"director": "Andrew Bergman",
	"summary": "In this charming romantic comedy ...",
	"poster": "http://netflixroulette.net/api/posters/643557.jpg",
	"mediatype": 0,
	"runtime": "101 min"
  }
     */
    public class Movie
    {
        public string Unit { get; set; }
        [JsonProperty("show_id")]
        public string ShowId { get; set; }
        [JsonProperty("show_title")]
        public string ShowTitle { get; set; }
        [JsonProperty("release_year")]
        public string ReleaseYear { get; set; }
        public string Rating { get; set; }
        [JsonProperty("show_cast")]
        public string ShowCast { get; set; }
        public string Director { get; set; }
        public string Summary { get; set; }
        public string Poster { get; set; }
        [JsonProperty("mediatype")]
        public string MediaType { get; set; }
        public string Runtime { get; set; }
    }
}
