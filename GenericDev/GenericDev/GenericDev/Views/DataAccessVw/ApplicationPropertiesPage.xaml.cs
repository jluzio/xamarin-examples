using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.Views.DataAccessVw
{
    public class Settings
    {
        public String Title { get; set; }
        public bool NotificationsEnabled { get; set; }
    }
    public class Keys
    {
        public static String TITLE = "Title";
        public static String NOTIFICATIONS_ENABLED = "NotificationsEnabled";
    }

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApplicationPropertiesPage : ContentPage
    {
        private Settings Settings;

        public ApplicationPropertiesPage ()
		{
			InitializeComponent ();

            Settings = LoadProperties();
            BindingContext = Settings;
		}

        private void OnChange(object sender, EventArgs e)
        {
            // saves on property change
            SaveProperties(Settings);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            // save on page leave
            SaveProperties(Settings);
        }

        private Settings LoadProperties()
        {
            var props = Application.Current.Properties;

            var settings = new Settings();
            if (props.ContainsKey(Keys.TITLE))
                settings.Title = (String)props[Keys.TITLE];
            if (props.ContainsKey(Keys.NOTIFICATIONS_ENABLED))
                settings.NotificationsEnabled = (bool)props[Keys.NOTIFICATIONS_ENABLED];
            return settings;
        }

        private void SaveProperties(Settings settings)
        {
            var props = Application.Current.Properties;
            props[Keys.TITLE] = settings.Title;
            props[Keys.NOTIFICATIONS_ENABLED] = settings.Title;

            // Saves on application sleep or closing
            // to save immediately use the following:
            // Application.Current.SavePropertiesAsync();
        }
    }
}