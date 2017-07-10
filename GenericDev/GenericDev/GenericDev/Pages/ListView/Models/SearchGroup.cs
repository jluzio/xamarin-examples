using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDev.ListView.Models
{
    class SearchGroup : List<Search>
    {
        public string Title { get; set; }
        public string ShortName { get; set; } //will be used for jump lists
        public string Subtitle { get; set; }

        public SearchGroup(String title = null, String shortName = null)
        {
            Title = title;
            ShortName = shortName;
        }
    }
}
