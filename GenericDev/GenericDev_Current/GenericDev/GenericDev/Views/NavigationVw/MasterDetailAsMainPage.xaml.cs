using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.Views.NavigationVw
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailAsMainPage : ContentPage
    {
        public MasterDetailAsMainPage()
        {
            InitializeComponent();
        }

        private void start_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new MasterDetail(true);
        }
    }
}