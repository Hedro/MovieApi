using System;

using Xamarin.Forms;
using SerieApi;

using SQLite.Net;

namespace MovieApi
{
	public class MainPage : ContentPage
	{
		Button buttonMovie = new Button()
		{
			Text = String.Format("Movies")
		};

		Button buttonSerie = new Button ()
		{
			Text = String.Format("Series")
		};

		Button buttonFav = new Button ()
		{
			Text = String.Format("Favori")
		};

		Button buttonSearch = new Button ()
		{
			Text = String.Format("Search")
		};
		
		public MainPage ()
		{
			this.Content = new StackLayout 
			{
				Children = 
				{
					buttonMovie,
					buttonSerie,
					buttonFav,
					buttonSearch
				},
			};

			buttonMovie.Clicked += async (sender, e) => 
			{
				buttonMovie.IsEnabled = buttonSearch.IsEnabled = buttonSerie.IsEnabled = buttonFav.IsEnabled = false;

				await Navigation.PushAsync (new TypePage("Movie"));

				buttonMovie.IsEnabled = buttonSearch.IsEnabled = buttonSerie.IsEnabled = buttonFav.IsEnabled = true;
			};

			buttonSerie.Clicked += async (sender, e) =>
			{
				buttonMovie.IsEnabled = buttonSearch.IsEnabled = buttonSerie.IsEnabled = buttonFav.IsEnabled = false;

				await Navigation.PushAsync (new TypePage("Serie"));

				buttonMovie.IsEnabled = buttonSearch.IsEnabled = buttonSerie.IsEnabled = buttonFav.IsEnabled = true;
			};

			buttonFav.Clicked += async (sender, e) => 
			{
				buttonMovie.IsEnabled = buttonSearch.IsEnabled = buttonSerie.IsEnabled = buttonFav.IsEnabled = false;

				await Navigation.PushAsync (new FavPage());

				buttonMovie.IsEnabled = buttonSearch.IsEnabled = buttonSerie.IsEnabled = buttonFav.IsEnabled = true;
			};

			buttonSearch.Clicked += async (sender, e) => 
			{
				buttonMovie.IsEnabled = buttonSearch.IsEnabled = buttonSerie.IsEnabled = buttonFav.IsEnabled = false;

				await Navigation.PushAsync (new SearchPage());

				buttonMovie.IsEnabled = buttonSearch.IsEnabled = buttonSerie.IsEnabled = buttonFav.IsEnabled = true;
			};
		}


	}
}