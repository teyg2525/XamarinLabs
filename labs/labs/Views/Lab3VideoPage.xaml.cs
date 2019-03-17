﻿using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace labs.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Lab3VideoPage : ContentPage
	{
		public Lab3VideoPage ()
		{
			InitializeComponent ();
            ViewModelLocator.SetAutowireViewModel(this, true);
        }
	}
}