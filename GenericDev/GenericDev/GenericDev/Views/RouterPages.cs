using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using GenericDev.Views.CommonVw;

namespace GenericDev.Views
{
    public class CurrentVwIndex : RouterPage
    {
        public CurrentVwIndex() : base()
        {
            Title = "Current";
            Pages.ItemsSource = new List<Page>
            {
                new GenericDev.Views.FormsVw.Exercise1.ContactListPage(),
            };
        }
    }


    public class MiscVwIndex : RouterPage
    {
        public MiscVwIndex() : base()
        {
            Title = "Misc";
            Pages.ItemsSource = new List<Page>
            {
                new GenericDev.Views.MiscVw.QuotesPage(),
                new GenericDev.Views.MiscVw.ResourceDictionaryPage(),
                new GenericDev.Views.MiscVw.DynamicResourcesPage(),
            };
        }
    }

    public class BindingVwIndex : RouterPage
    {
        public BindingVwIndex() : base()
        {
            Title = "Binding";
            Pages.ItemsSource = new List<Page>
            {
                new GenericDev.Views.BindingVw.BackwardsBindings(),
            };
        }
    }

    public class StackLayoutVwIndex : RouterPage
    {
        public StackLayoutVwIndex() : base()
        {
            Title = "Stack Layout";
            Pages.ItemsSource = new List<Page>
            {
                new GenericDev.Views.StackLayoutVwVw.Exercise1(),
                new GenericDev.Views.StackLayoutVwVw.Exercise2(),
            };
        }
    }

    public class AbsoluteLayoutVwIndex : RouterPage
    {
        public AbsoluteLayoutVwIndex() : base()
        {
            Title = "Absolute Layout";
            Pages.ItemsSource = new List<Page>
            {
                new GenericDev.Views.AbsoluteLayoutVw.Exercise1(),
                new GenericDev.Views.AbsoluteLayoutVw.Exercise2(),
                new GenericDev.Views.AbsoluteLayoutVw.CheckerBoardPage(),
                new GenericDev.Views.AbsoluteLayoutVw.TestingValues()
            };
        }
    }

    public class GridVwIndex : RouterPage
    {
        public GridVwIndex() : base()
        {
            Title = "Grid";
            Pages.ItemsSource = new List<Page>
            {
                new GenericDev.Views.GridVw.Exercise1(),
                new GenericDev.Views.GridVw.Exercise2(),
            };
        }
    }

    public class RelativeLayoutVwIndex : RouterPage
    {
        public RelativeLayoutVwIndex() : base()
        {
            Title = "Relative Layout";
            Pages.ItemsSource = new List<Page>
            {
                new GenericDev.Views.RelativeLayoutVw.Exercise1(),
            };
        }
    }

    public class ImageVwIndex : RouterPage
    {
        public ImageVwIndex() : base()
        {
            Title = "Image";
            Pages.ItemsSource = new List<Page>
            {
                new GenericDev.Views.ImageVw.EmbeddedImage(),
                new GenericDev.Views.ImageVw.LocalImage(),
                new GenericDev.Views.ImageVw.LoadingIndicator(),
                new GenericDev.Views.ImageVw.LoadingIndicatorExternalImage(),
                new GenericDev.Views.ImageVw.ImageCirclePlugin(),
                new GenericDev.Views.ImageVw.Exercise1(),
            };
        }
    }

    public class ListViewVwIndex : RouterPage
    {
        public ListViewVwIndex() : base()
        {
            Title = "List View";
            Pages.ItemsSource = new List<Page>
            {
                new GenericDev.Views.ListViewVw.Exercise1(),
            };
        }
    }

    public class NavigationVwIndex : RouterPage
    {
        public NavigationVwIndex() : base()
        {
            Title = "Navigation";
            Pages.ItemsSource = new List<Page>
            {
                new GenericDev.Views.NavigationVw.Tabs(),
                new GenericDev.Views.NavigationVw.Carousel(),
                new GenericDev.Views.NavigationVw.MasterDetail(),
                new GenericDev.Views.NavigationVw.MasterDetailAsMainPage(),
                new GenericDev.Views.NavigationVw.MasterDetailNavigateToPage(),
                new GenericDev.Views.NavigationVw.MasterDetailNavigateToModal(),
                new GenericDev.Views.NavigationVw.Popups(),
                new GenericDev.Views.NavigationVw.ToolbarItemsPage()
            };
        }
    }

    public class FormsVwIndex : RouterPage
    {
        public FormsVwIndex() : base()
        {
            Title = "Forms";
            Pages.ItemsSource = new List<Page>
            {
                new GenericDev.Views.FormsVw.FormElements(),
                new GenericDev.Views.FormsVw.PickerElements(),
                new GenericDev.Views.FormsVw.TableViewPage(),
                new GenericDev.Views.FormsVw.Exercise1.Exercise1(),
            };
        }
    }


    public class DataAccessVwIndex : RouterPage
    {
        public DataAccessVwIndex() : base()
        {
            Title = "Data Access";
            Pages.ItemsSource = new List<Page>
            {
                new GenericDev.Views.DataAccessVw.ApplicationPropertiesPage(),
                new GenericDev.Views.DataAccessVw.ApplicationPropertiesV2Page(),
                new GenericDev.Views.DataAccessVw.FileStoragePage(),
                new GenericDev.Views.DataAccessVw.SQLiteExamplePage(),
                new GenericDev.Views.DataAccessVw.RestServicePage(),
                new GenericDev.Views.DataAccessVw.Exercise1.MoviesPage(),
            };
        }
    }

}
