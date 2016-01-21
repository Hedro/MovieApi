﻿using MovieApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MovieApi
{
	public class DetailMoviePage : ContentPage
	{
		private MovieOrSerieIsFavDataBase _database;

		public DetailsMovieViewModel movieDetails { get; set; }

		public DetailMoviePage(string id)
		{
			_database = new MovieOrSerieIsFavDataBase ();

			string queryString = "https://api-v2launch.trakt.tv/movies/" + id + "?extended=full,images";

			Image favImage = new Image();
			favImage.Source = "etoileOff.jpg";

			var image_off = 1;

			movieDetails = Core.GetMovieDetails(queryString);

			string urlImdb = "http://www.imdb.com/title/" + movieDetails.Imdb + "/?ref_=fn_al_tt_1";

			var webImage = new Image { Aspect = Aspect.AspectFit };
			if (movieDetails.UrlImage != null) 
			{
				webImage.Source = ImageSource.FromUri(new Uri(movieDetails.UrlImage));
			}
			else
			{
				webImage.Source = ImageSource.FromUri (new Uri("http://sd.keepcalm-o-matic.co.uk/i/error-404-democracy-not-found.png"));
			}

			TextCell redirectImdb = new TextCell
			{
				Text = "imdb",
				Detail = "Go on imdb.com"
			};

			if (movieDetails.Imdb != null && movieDetails.Imdb != "") 
			{
				redirectImdb.Tapped += (s, e) => {
					Device.OpenUri (new Uri (urlImdb));
				};
			}
			else
			{
				redirectImdb.Detail = "No imdb";
			}

			ImageCell imageFavoris = new ImageCell
			{
				ImageSource = favImage.Source,
			};

			TextCell redirectToYoutubeTrailer = new TextCell
			{
				Text = "Trailer",
				Detail = "Go on youtube trailer"
			};

			if (movieDetails.UrlTrailer != null && movieDetails.UrlTrailer != "") 
			{
				redirectToYoutubeTrailer.Tapped += (s, e) => {
					Device.OpenUri (new Uri (movieDetails.UrlTrailer));
				};
			}
			else
			{
				redirectToYoutubeTrailer.Detail = "No trailer";
			}

			var layout = new StackLayout
			{

			};

			var sect1 = new TableView
			{
				Root = new TableRoot("Table Title")
				{

					new TableSection(movieDetails.Title +' '+ movieDetails.Year+" ("+movieDetails.Language+')')
					{
						imageFavoris,

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
						new TextCell
						{
							Text = movieDetails.OverView,
						},
					},
				}
			};

			layout.Children.Add(sect1);

			imageFavoris.Tapped += (s, e) =>
			{
				if (image_off == 1)
				{
					image_off = 0;
					layout.Children.Remove(sect1);
					imageFavoris.ImageSource = "etoileOn.png";
					layout.Children.Add(sect1);
				}
				else
				{
					image_off = 1;
					layout.Children.Remove(sect1);
					imageFavoris.ImageSource = "etoileOff.png";
					layout.Children.Add(sect1);
				}
			};

			Content = layout;
		}
	}
}