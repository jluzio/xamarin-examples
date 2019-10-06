using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using GenericDev.Config;

[assembly: Dependency(typeof(ImageConfig))]
namespace GenericDev.Config
{
    class ImageConfig
    {
        public String Root
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.UWP:
                        return "Content/Images/";
                    default:
                        return "";
                }
            }
        }
    }
}
