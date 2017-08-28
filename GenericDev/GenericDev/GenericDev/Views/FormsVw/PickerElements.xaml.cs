using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.Views.FormsVw
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class PickerElements : ContentPage
	{
        public IList<Monkey> Monkeys { get; set; }

		public PickerElements ()
		{
			InitializeComponent ();
            Monkeys = GetMonkeys();
            BindingContext = this;

            datePicker2.MaximumDate = DateTime.Today.AddYears(1);
            datePicker2.MinimumDate = DateTime.Today.AddYears(-1);
        }

        private IList<Monkey> GetMonkeys()
        {
            return new List<Monkey>
            {
                new Monkey{ Name = "Caesar", Details = "Ruler of Monkeys" },
                new Monkey{ Name = "Koba", Details = "Adversary of Humans" }
            };
        }

        private void simplePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = simplePicker.SelectedItem as string;
            DisplayAlert("Selection", selected, "OK");
        }

        private void picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = picker.SelectedItem as Monkey;
            DisplayAlert("Selection", selected.Name, "OK");
        }

        private void datePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            DisplayAlert("Selection", e.NewDate.ToString(), "OK");
        }

        private DateTime MinimumDate
        {
            get
            {
                return DateTime.Today.AddYears(-1);
            }
        }

        private DateTime MaximumDate
        {
            get
            {
                return DateTime.Today.AddYears(+1);
            }
        }
    }

}