using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.Views.ExtensionsVw
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DateCell : ViewCell
	{
        public static readonly BindableProperty LabelProperty = 
            BindableProperty.Create("Label", typeof(String), typeof(DateCell));

        public String Label {
            get { return (String)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

		public DateCell ()
		{
			InitializeComponent ();
            BindingContext = this;
		}
	}
}