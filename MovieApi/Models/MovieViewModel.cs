﻿using System;

using Xamarin.Forms;

namespace MovieApi
{
	public class MovieViewModel : ContentPage
	{
		public string Identifiant { get; set; }
		public string Name { get; set; }
		public long Year { get; set; }
		public string URLImage { get; set; }
		public ImageSource Image { get; set; }

		public MovieViewModel ()
		{
			
		}
	}
}


