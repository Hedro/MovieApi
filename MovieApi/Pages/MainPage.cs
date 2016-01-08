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
				await Navigation.PushAsync (new TypePage("Movie"));
			};

			buttonSerie.Clicked += async (sender, e) => 
			{
				await Navigation.PushAsync (new TypePage("Serie"));
			};

			buttonSearch.Clicked += async (sender, e) => 
			{
				//await Navigation.PushAsync ();
			};
		}
	}
}


