using System;

using Xamarin.Forms;
using SerieApi;

using SQLite.Net;

namespace MovieApi
{
	public class MainPage : ContentPage
	{
		private MovieOrSerieIsFavDataBase _database;

		Button buttonMovie = new Button()
		{
			Text = String.Format("Movies")
		};

		Button buttonSerie = new Button ()
		{
			Text = String.Format("Series")
		};

		Button buttonSearch = new Button ()
		{
			Text = String.Format("Search")
		};
		
		public MainPage ()
		{
			_database = new MovieOrSerieIsFavDataBase ();

			this.Content = new StackLayout 
			{
				Children = 
				{
					buttonMovie,
					buttonSerie,
					buttonSearch
				},
			};

			buttonMovie.Clicked += async (sender, e) => 
			{
				buttonMovie.IsEnabled = buttonSearch.IsEnabled = buttonSerie.IsEnabled = false;

				await Navigation.PushAsync (new TypePage("Movie"));

				buttonMovie.IsEnabled = buttonSearch.IsEnabled = buttonSerie.IsEnabled = true;
			};

			buttonSerie.Clicked += async (sender, e) => 
			{
				buttonMovie.IsEnabled = buttonSearch.IsEnabled = buttonSerie.IsEnabled = false;

				await Navigation.PushAsync (new TypePage("Serie"));

				buttonMovie.IsEnabled = buttonSearch.IsEnabled = buttonSerie.IsEnabled = true;
			};

			buttonSearch.Clicked += async (sender, e) => 
			{
				buttonMovie.IsEnabled = buttonSearch.IsEnabled = buttonSerie.IsEnabled = false;

				await Navigation.PushAsync (new SearchPage());

				buttonMovie.IsEnabled = buttonSearch.IsEnabled = buttonSerie.IsEnabled = true;
			};
		}


	}
}


