using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using Xamarin.Forms;

using GenericDev.iOS.Config;
using GenericDev.Config;

[assembly: Dependency(typeof(SystemInfo))]
namespace GenericDev.iOS.Config
{
    class SystemInfo : ISystemInfo
    {
        public string Title()
        {
            return "GenericDev.iOS";
        }
    }
}