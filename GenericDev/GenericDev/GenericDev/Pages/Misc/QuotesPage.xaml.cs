using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.Misc
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuotesPage : ContentPage
    {
        public DateTime quotesDateTime { get; } = System.DateTime.Now;

        private string[] quotes =
        {
            "Quote 1",
            "Quote 2",
            "Quote 3"
        };
        private int index = 0;

        public QuotesPage()
        {
            InitializeComponent();
            updateQuote();
        }

        private void OnNextClick(object sender, EventArgs e)
        {
            index = (index + 1) % quotes.Length;
            updateQuote();
        }

        private void updateQuote()
        {
            currentQuote.Text = quotes[index];
        }
    }
}