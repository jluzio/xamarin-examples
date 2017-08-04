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
        public bool OnChangeEnabled { get; set; } = true;
        public bool OnLeavePageEnabled { get; set; } = true;
    }

    public class Keys
    {
        public const String Title = "Title";
        public const String NotificationsEnabled = "NotificationsEnabled";
        public const String OnChangeEnabled = "OnChangeEnabled";
        public const String OnLeavePageEnabled = "OnLeavePageEnabled";
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
            if (Settings.OnChangeEnabled)
            {
                // saves on property change
                SaveProperties(Settings);
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            if (Settings.OnLeavePageEnabled)
            {
                // save on page leave
                SaveProperties(Settings);
            }
        }

        private Settings LoadProperties()
        {
            var props = Application.Current.Properties;

            var settings = new Settings();
            if (props.ContainsKey(Keys.Title))
                settings.Title = (String)props[Keys.Title];
            if (props.ContainsKey(Keys.NotificationsEnabled))
                settings.NotificationsEnabled = (bool)props[Keys.NotificationsEnabled];
            if (props.ContainsKey(Keys.OnChangeEnabled))
                settings.OnChangeEnabled = (bool)props[Keys.OnChangeEnabled];
            if (props.ContainsKey(Keys.OnLeavePageEnabled))
                settings.OnLeavePageEnabled = (bool)props[Keys.OnLeavePageEnabled];
            return settings;
        }

        private void SaveProperties(Settings settings)
        {
            var props = Application.Current.Properties;

            props[Keys.Title] = settings.Title;
            props[Keys.NotificationsEnabled] = settings.NotificationsEnabled;
            props[Keys.OnChangeEnabled] = settings.OnChangeEnabled;
            props[Keys.OnLeavePageEnabled] = settings.OnLeavePageEnabled;

            // Saves on application sleep or closing
            // to save immediately use the following:
            // Application.Current.SavePropertiesAsync();
        }
    }
}