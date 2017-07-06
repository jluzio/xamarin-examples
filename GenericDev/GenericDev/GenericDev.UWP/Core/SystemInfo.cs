using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using GenericDev.Core;
using GenericDev.UWP.Core;

[assembly: Dependency(typeof(SystemInfo))]
namespace GenericDev.UWP.Core
{
    class SystemInfo : ISystemInfo
    {
        public string Title()
        {
            return "GenericDev.UWP";
        }
    }
}
