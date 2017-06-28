using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms;

using GenericDev.Core;
using GenericDev.Droid.Core;

[assembly: Dependency(typeof(SystemInfo))]
namespace GenericDev.Droid.Core
{
    public class SystemInfo : ISystemInfo
    {
        public string Title()
        {
            return "GenericDev.Android";
        }
    }
}