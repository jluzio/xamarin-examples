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
	public partial class EventSenderPage : ContentPage
	{
		public EventSenderPage ()
		{
			InitializeComponent ();
		}

        private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            MessagingCenter.Send(this, Events.SliderChangeValueEvent.ToString(), e.NewValue);
        }
    }
}