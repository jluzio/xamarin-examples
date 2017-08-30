using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.Views.MiscVw.MessagingCenterVw
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EventSubscriberPage : ContentPage
	{
		public EventSubscriberPage ()
		{
			InitializeComponent ();
            MessagingCenter.Subscribe<EventSenderPage, double>(
                this,
                Events.SliderChangeValueEvent.ToString(), 
                OnSliderValueChange);
		}

        private void gotoPageBtn_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new EventSenderPage());
        }

        private void OnSliderValueChange(Object sender, double value)
        {
            System.Diagnostics.Debug.WriteLine($"EventSubscriberPage.OnSliderValueChange({sender}, {value})");
            sliderTargetValue.Text = $"Slider value: {value}";
        }
    }
}