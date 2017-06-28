﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GenericDev.RelativeLayoutExamples
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ExamplesPage : ContentPage
	{
		public ExamplesPage ()
		{
			InitializeComponent ();
		}

        async private void OnExercise1ButtonClick(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Exercise1());
        }

    }
}