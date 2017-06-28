using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using Xamarin.Forms;

using GenericDev.iOS.Core;
using GenericDev.Core;

[assembly: Dependency(typeof(SystemInfo))]
namespace GenericDev.iOS.Core
{
    class SystemInfo : ISystemInfo
    {
        public string Title()
        {
            return "GenericDev.iOS";
        }
    }
}