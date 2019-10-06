using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using GenericDev.Config;
using GenericDev.UWP.Config;

[assembly: Dependency(typeof(SystemInfo))]
namespace GenericDev.UWP.Config
{
    class SystemInfo : ISystemInfo
    {
        public string Title()
        {
            return "GenericDev.UWP";
        }
    }
}
