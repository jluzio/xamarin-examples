using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GenericDev.ListView.Models;

namespace GenericDev.ListView.Services
{
    interface ISearchService
    {
        IEnumerable<Search> GetSearches(String filter = null);
        void DeleteSearch(int searchId);
    }
}
