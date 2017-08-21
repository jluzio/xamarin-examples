using GenericDev.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.Views.DataAccessVw
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SQLiteExamplePage : ContentPage
    {
        public SQLiteExamplePage()
        {
            InitializeComponent();

            var tester = new DatabaseTest();
            tester.Test();
        }
    }
}