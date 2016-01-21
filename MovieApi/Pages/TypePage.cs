using System;

using Xamarin.Forms;
using SerieApi;

namespace MovieApi
{
	public class TypePage : ContentPage
	{
		public TypePage(string type)
		{
			Button buttonPopular = new Button
			{
				Text = String.Format("Popular")
			};

			Button buttonAnticipated = new Button
			{
				Text = String.Format("Anticipated")
			};

			Button buttonTrending = new Button
			{
				Text = String.Format("Trending")
			};

			Button buttonBoxOffice = new Button
			{
				Text = String.Format("Box Office")
			};

			Button buttonWatched = new Button
			{
				Text = String.Format("Watched")
			};

			if (type == "Movie") 
			{
				this.Content = new StackLayout
				{
					Children = 
					{
						buttonPopular,
						buttonAnticipated,
						buttonTrending,
						buttonBoxOffice,
						buttonWatched
					},
				};
			}
			else
			{
				this.Content = new StackLayout
				{
					Children = 
					{
						buttonPopular,
						buttonAnticipated,
						buttonTrending,
						buttonWatched
					},
				};
			}

			buttonPopular.Clicked += async (sender, e) => 
			{
				buttonPopular.IsEnabled = buttonAnticipated.IsEnabled = buttonTrending.IsEnabled = buttonBoxOffice.IsEnabled = buttonWatched.IsEnabled = false;

				await Navigation.PushAsync (choix(type,"Popular"));

				buttonPopular.IsEnabled = buttonAnticipated.IsEnabled = buttonTrending.IsEnabled = buttonBoxOffice.IsEnabled = buttonWatched.IsEnabled = true;
			};

			buttonAnticipated.Clicked += async (sender, e) => 
			{
				buttonPopular.IsEnabled = buttonAnticipated.IsEnabled = buttonTrending.IsEnabled = buttonBoxOffice.IsEnabled = buttonWatched.IsEnabled = false;

				await Navigation.PushAsync (choix(type,"Anticipated"));

				buttonPopular.IsEnabled = buttonAnticipated.IsEnabled = buttonTrending.IsEnabled = buttonBoxOffice.IsEnabled = buttonWatched.IsEnabled = true;
			};

			buttonTrending.Clicked += async (sender, e) => 
			{
				buttonPopular.IsEnabled = buttonAnticipated.IsEnabled = buttonTrending.IsEnabled = buttonBoxOffice.IsEnabled = buttonWatched.IsEnabled = false;

				await Navigation.PushAsync (choix(type,"Trending"));

				buttonPopular.IsEnabled = buttonAnticipated.IsEnabled = buttonTrending.IsEnabled = buttonBoxOffice.IsEnabled = buttonWatched.IsEnabled = true;
			};

			if (type == "Movie") 
			{
				buttonBoxOffice.Clicked += async (sender, e) => 
				{
					buttonPopular.IsEnabled = buttonAnticipated.IsEnabled = buttonTrending.IsEnabled = buttonBoxOffice.IsEnabled = buttonWatched.IsEnabled = false;

					await Navigation.PushAsync (choix(type,"BoxOffice"));

					buttonPopular.IsEnabled = buttonAnticipated.IsEnabled = buttonTrending.IsEnabled = buttonBoxOffice.IsEnabled = buttonWatched.IsEnabled = true;
				};
			}

			buttonWatched.Clicked += async (sender, e) => 
			{
				buttonPopular.IsEnabled = buttonAnticipated.IsEnabled = buttonTrending.IsEnabled = buttonBoxOffice.IsEnabled = buttonWatched.IsEnabled = false;

				await Navigation.PushAsync (choix(type,"Watched"));

				buttonPopular.IsEnabled = buttonAnticipated.IsEnabled = buttonTrending.IsEnabled = buttonBoxOffice.IsEnabled = buttonWatched.IsEnabled = true;
			};
		}

		dynamic choix(string type, string liste)
		{
			if (type == "Movie") 
			{
				return new MoviePage (liste);
			}
			else
			{
				return new SeriePage (liste);
			}
		}
	}
}