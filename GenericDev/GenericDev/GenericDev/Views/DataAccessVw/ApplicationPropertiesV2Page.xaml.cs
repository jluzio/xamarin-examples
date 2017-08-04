using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.Views.DataAccessVw
{
    public class KeysV2
    {
        public const String Title = "Title";
        public const String NotificationsEnabled = "NotificationsEnabled";
    }

    public class SettingsV2
    {
        public String Title
        {
            get
            {
                return GetProperty(KeysV2.Title, "");
            }
            set
            {
                SetProperty(KeysV2.Title, value);
            }
        }

        public bool NotificationsEnabled
        {
            get
            {
                return GetProperty(KeysV2.NotificationsEnabled, true);
            }
            set
            {
                SetProperty(KeysV2.NotificationsEnabled, value);
            }
        }

        public static T GetProperty<T>(String key, T defaultValue)
        {
            var props = Application.Current.Properties;
            if (props.ContainsKey(key))
            {
                return (T)props[key];
            }
            return defaultValue;
        }

        public static void SetProperty(String key, Object value)
        {
            Application.Current.Properties[key] = value;
        }
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApplicationPropertiesV2Page : ContentPage
    {
        public ApplicationPropertiesV2Page ()
		{
			InitializeComponent ();
            BindingContext = new SettingsV2();
		}
    }
}