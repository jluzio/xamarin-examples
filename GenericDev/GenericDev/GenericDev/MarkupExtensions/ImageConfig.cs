using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using GenericDev.MarkupExtensions;

[assembly: Dependency(typeof(ImageConfig))]
namespace GenericDev.MarkupExtensions
{
    class ImageConfig
    {
        public String Root
        {
            get
            {
                switch (Device.RuntimePlatform)
                {
                    case Device.Windows:
                    case Device.WinPhone:
                        return "ResourcesImages/";
                    default:
                        return "";
                }
            }
        }
    }
}
