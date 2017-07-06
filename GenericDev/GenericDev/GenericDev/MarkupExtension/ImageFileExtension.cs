using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.MarkupExtension
{
    [ContentProperty("Source")]
    public class ImageFileExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }
            // Do your translation lookup here, using whatever method you require
            var imageConfig = DependencyService.Get<ImageConfig>();
            System.Diagnostics.Debug.WriteLine(String.Format("imageConfig: {0} ", imageConfig));
            var file = imageConfig.Root + Source;
            System.Diagnostics.Debug.WriteLine(String.Format("file: '{0}' ", file));
            var imageSource = ImageSource.FromFile(file);

            return imageSource;
        }
    }
}
