using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace MovieApi
{
	public partial class MainPageXaml : ContentPage
	{
		public MainPageXaml ()
		{
			InitializeComponent ();

			Title = "MovieApi";

			MovieButton.Clicked += async (sender, e) => 
			{
				MovieButton.IsEnabled = SearchButton.IsEnabled = SerieButton.IsEnabled = FavButton.IsEnabled = false;

				await Navigation.PushAsync (new TypePageXaml("Movie"));

				MovieButton.IsEnabled = SearchButton.IsEnabled = SerieButton.IsEnabled = FavButton.IsEnabled = true;
			};

			SerieButton.Clicked += async (sender, e) =>
			{
				MovieButton.IsEnabled = SearchButton.IsEnabled = SerieButton.IsEnabled = FavButton.IsEnabled = false;

				await Navigation.PushAsync (new TypePageXaml("Serie"));

				MovieButton.IsEnabled = SearchButton.IsEnabled = SerieButton.IsEnabled = FavButton.IsEnabled = true;
			};

			FavButton.Clicked += async (sender, e) => 
			{
				MovieButton.IsEnabled = SearchButton.IsEnabled = SerieButton.IsEnabled = FavButton.IsEnabled = false;

				await Navigation.PushAsync (new FavPage());

				MovieButton.IsEnabled = SearchButton.IsEnabled = SerieButton.IsEnabled = FavButton.IsEnabled = true;
			};

			SearchButton.Clicked += async (sender, e) => 
			{
				MovieButton.IsEnabled = SearchButton.IsEnabled = SerieButton.IsEnabled = FavButton.IsEnabled = false;

				await Navigation.PushAsync (new SearchPage());

				MovieButton.IsEnabled = SearchButton.IsEnabled = SerieButton.IsEnabled = FavButton.IsEnabled = true;
			};
		}
	}
}

