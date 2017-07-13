using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GenericDev.Views.ListView.Models;

namespace GenericDev.Views.ListView.Services
{
    interface ISearchService
    {
        IEnumerable<Search> GetSearches(String filter = null);
        void DeleteSearch(int searchId);
        void Reload();
    }
}
