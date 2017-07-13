using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using GenericDev.Views.Common;

namespace GenericDev.Views
{
    public class AbsoluteLayoutIndex : RouterPage
    {
        public AbsoluteLayoutIndex() : base()
        {
            Title = "Absolute Layout";
            Pages.ItemsSource = new List<Page>
            {
                new GenericDev.Views.AbsoluteLayout.Exercise1(),
                new GenericDev.Views.AbsoluteLayout.Exercise2(),
                new GenericDev.Views.AbsoluteLayout.CheckerBoardPage(),
                new GenericDev.Views.AbsoluteLayout.TestingValues()
            };
        }
    }

    public class BindingIndex : RouterPage
    {
        public BindingIndex() : base()
        {
            Title = "Binding";
            Pages.ItemsSource = new List<Page>
            {
                new GenericDev.Views.Binding.BackwardsBindings(),
            };
        }
    }

    public class GridIndex : RouterPage
    {
        public GridIndex() : base()
        {
            Title = "Grid";
            Pages.ItemsSource = new List<Page>
            {
                new GenericDev.Views.Grid.Exercise1(),
                new GenericDev.Views.Grid.Exercise2(),
            };
        }
    }

    public class ImageIndex : RouterPage
    {
        public ImageIndex() : base()
        {
            Title = "Image";
            Pages.ItemsSource = new List<Page>
            {
                new GenericDev.Views.Image.EmbeddedImage(),
                new GenericDev.Views.Image.LocalImage(),
                new GenericDev.Views.Image.LoadingIndicator(),
                new GenericDev.Views.Image.LoadingIndicatorExternalImage(),
                new GenericDev.Views.Image.ImageCirclePlugin(),
                new GenericDev.Views.Image.Exercise1(),
            };
        }
    }

    public class ListViewIndex : RouterPage
    {
        public ListViewIndex() : base()
        {
            Title = "List View";
            Pages.ItemsSource = new List<Page>
            {
                new GenericDev.Views.ListView.Exercise1(),
            };
        }
    }

    public class MiscIndex : RouterPage
    {
        public MiscIndex() : base()
        {
            Title = "Misc";
            Pages.ItemsSource = new List<Page>
            {
                new GenericDev.Views.Misc.QuotesPage(),
            };
        }
    }

    public class NavigationIndex : RouterPage
    {
        public NavigationIndex() : base()
        {
            Title = "Navigation";
            Pages.ItemsSource = new List<Page>
            {
                new GenericDev.Views.Navigation.Tabs(),
                new GenericDev.Views.Navigation.Carousel(),
                new GenericDev.Views.Navigation.MasterDetail(),
            };
        }
    }

    public class RelativeLayoutIndex : RouterPage
    {
        public RelativeLayoutIndex() : base()
        {
            Title = "Relative Layout";
            Pages.ItemsSource = new List<Page>
            {
                new GenericDev.Views.RelativeLayout.Exercise1(),
            };
        }
    }

    public class StackLayoutIndex : RouterPage
    {
        public StackLayoutIndex() : base()
        {
            Title = "Stack Layout";
            Pages.ItemsSource = new List<Page>
            {
                new GenericDev.Views.StackLayout.Exercise1(),
                new GenericDev.Views.StackLayout.Exercise2(),
            };
        }
    }

}
