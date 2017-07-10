using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using GenericDev.Config;

namespace GenericDev
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();

            var systemInfo = DependencyService.Get<ISystemInfo>();
            if (systemInfo != null)
            {
                systemInfoLabel.Text = systemInfo.Title();
            } else {
                systemInfoLabel.Text = "<Undefined systemInfo.Title()>";
            }
        }
    }
}
