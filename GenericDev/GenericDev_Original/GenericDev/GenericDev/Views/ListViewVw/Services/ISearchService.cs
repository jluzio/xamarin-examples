using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GenericDev.Views.ListViewVw.Models;

namespace GenericDev.Views.ListViewVw.Services
{
    interface ISearchService
    {
        IEnumerable<Search> GetSearches(string filter = null);
        void DeleteSearch(int searchId);
        void Reload();
    }
}
