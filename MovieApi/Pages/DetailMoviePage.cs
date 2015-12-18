using System;

using Xamarin.Forms;

namespace MovieApi
{
	public class DetailMoviePage : ContentPage
	{
		public DetailMoviePage ()
		{
			Content = new StackLayout { 
				Children = {
					new Label { Text = "Hello ContentPage" }
				}
			};
		}
	}
}


