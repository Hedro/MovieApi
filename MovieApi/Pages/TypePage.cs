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
				await Navigation.PushAsync (choix(type,"Popular"));
			};

			buttonAnticipated.Clicked += async (sender, e) => 
			{
				await Navigation.PushAsync (choix(type,"Anticipated"));
			};

			buttonTrending.Clicked += async (sender, e) => 
			{
				await Navigation.PushAsync (choix(type,"Trending"));
			};

			if (type == "Movie") 
			{
				buttonBoxOffice.Clicked += async (sender, e) => 
				{
					await Navigation.PushAsync (choix(type,"BoxOffice"));
				};
			}

			buttonWatched.Clicked += async (sender, e) => 
			{
				await Navigation.PushAsync (choix(type,"Watched"));
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


