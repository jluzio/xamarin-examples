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
using BootcampTap.Core;
using GalaSoft.MvvmLight.Views;

namespace BootcampTap.Droid.Activities
{
    [Activity(Label = "SplashScreenActivity", Theme = "@style/AppTheme", MainLauncher =true)]
    public class SplashScreenActivity : ActivityBase
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }

        protected override void OnResume()
        {
            base.OnResume();
            App.Start();
        }
    }
}