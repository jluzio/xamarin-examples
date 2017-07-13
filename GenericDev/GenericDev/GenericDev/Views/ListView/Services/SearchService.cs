using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using GenericDev.Views.ListView.Services;
using GenericDev.Views.ListView.Models;

[assembly: Dependency(typeof(SearchService))]
namespace GenericDev.Views.ListView.Services
{
    class SearchService : ISearchService
    {
        private List<Search> SearchList;

        public SearchService()
        {
            SearchList = NewSearches();
        }

        public IEnumerable<Search> GetSearches(string filter = null)
        {
            IEnumerable<Search> results = SearchList;
            if (!String.IsNullOrWhiteSpace(filter))
            {
                results = SearchList.Where( search => search.Location.ToLower().Contains(filter.ToLower()) ).ToList();
            }
            return results;
        }

        public void DeleteSearch(int searchId)
        {
            SearchList.RemoveAll(search => search.Id == searchId);
        }

        public void Reload()
        {
            SearchList = NewSearches();
        }

        private List<Search> NewSearches()
        {
            var dateTime1 = System.DateTime.Today.AddMonths(-12);
            var dateTime2 = System.DateTime.Today.AddMonths(-11);
            var dateTime3 = System.DateTime.Today.AddMonths(-10);
            var dateTime4 = System.DateTime.Today.AddMonths(-9);

            var values = new List<Search>
            {
                new Search { Id = 1, Location = "Lisboa", CheckIn = dateTime1, CheckOut = dateTime2 },
                new Search { Id = 2, Location = "Barreiro", CheckIn = dateTime2, CheckOut = dateTime3 },
                new Search { Id = 3, Location = "Setubal", CheckIn = dateTime3, CheckOut = dateTime4 },
            };
            return values;
        }
    }
}
