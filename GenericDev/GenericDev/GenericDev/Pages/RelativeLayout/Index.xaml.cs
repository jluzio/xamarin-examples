﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.RelativeLayout
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Index : ContentPage
	{
		public Index()
		{
			InitializeComponent ();
		}

        async private void OnExercise1ButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Exercise1());
        }

    }
}