using System;

using Xamarin.Forms;
using SerieApi;

namespace MovieApi
{
	public class MainPage : ContentPage
	{
		public MainPage ()
		{
			Button buttonMovie = new Button()
			{
				Text = String.Format("Top 10 Movies")
			};

			Button buttonSerie = new Button ()
			{
				Text = String.Format("Top 10 Series")
			};

			this.Content = new StackLayout 
			{
				Children = 
				{
					buttonMovie,
					buttonSerie
				},
			};

			buttonMovie.Clicked += async (sender, e) => 
			{
				await Navigation.PushAsync (new MoviePage());
			};

			buttonSerie.Clicked += async (sender, e) => 
			{
				await Navigation.PushAsync (new SeriePage());
			};
		}
	}
}


