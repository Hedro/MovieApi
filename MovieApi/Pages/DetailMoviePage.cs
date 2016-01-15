using MovieApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MovieApi
{
	public class DetailsMoviePage : ContentPage
	{
		public DetailsMovieViewModel movieDetails { get; set; }

		public DetailsMoviePage(string id)
		{
			string queryString = "https://api-v2launch.trakt.tv/movies/" + id + "?extended=full,images";

			movieDetails = Core.GetMovieDetails(queryString);

			string urlImdb = "http://www.imdb.com/title/" + movieDetails.Imdb + "/?ref_=fn_al_tt_1";

			var webImage = new Image { Aspect = Aspect.AspectFit };
			webImage.Source = ImageSource.FromUri(new Uri(movieDetails.UrlImage));
			var imdbimage = new Image();

			TextCell redirectImdb = new TextCell
			{
				Text = "imdb",
				Detail = "Go on imdb.com"
			};

			redirectImdb.Tapped += (s, e) => {
				Device.OpenUri(new Uri(urlImdb));
			};

			TextCell redirectToYoutubeTrailer = new TextCell
			{
				Text = "Trailer",
				Detail = "Go on youtube trailer"
			};

			redirectToYoutubeTrailer.Tapped += (s, e) => {
				Device.OpenUri(new Uri(movieDetails.UrlTrailer));
			};

			var layout = new StackLayout
			{

			};

			Grid grid = new Grid
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 145,

				ColumnDefinitions = 
				{
					new ColumnDefinition {Width = new GridLength(.1, GridUnitType.Star)},
				}
			};

			grid.Children.Add(new Label { Text = movieDetails.OverView }, 0, 4, 0,1);

			var sect1 = new TableView
			{
				Root = new TableRoot("Table Title")
				{
					new TableSection(movieDetails.Title +' '+ movieDetails.Year+" ("+movieDetails.Language+')')
					{
						new ImageCell
						{
							Detail = movieDetails.Tagline,
							ImageSource = webImage.Source,
						},

						new TextCell
						{
							Text = "Certification",
							Detail = movieDetails.Certification,
						},

						new TextCell
						{
							Text = "Rating ("+movieDetails.Vote+" votes)",
							Detail = movieDetails.Rating.ToString(),
						},
						new TextCell
						{
							Text = "Realeased",
							Detail = movieDetails.Released,
						},

						redirectImdb,
						redirectToYoutubeTrailer,
						new TextCell
						{
							Text = "Overview",

						},
					},
				}
			};

			layout.Children.Add(sect1);
			layout.Children.Add(grid);

			Content = layout;
		}
	}
}