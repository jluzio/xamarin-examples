using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StackLayoutPage : ContentPage
    {
        public StackLayoutPage()
        {
            InitializeComponent();
        }

        async private void OnExercise1ButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new StackLayoutExercise1());
        }

        async private void OnExercise2ButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new StackLayoutExercise2());
        }
    }
}