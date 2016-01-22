using MovieApi.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

using SQLite;

namespace MovieApi
{
	public class DetailSeriePage : ContentPage
	{
		private MovieOrSerieIsFavDataBase _database;

		public DetailsSerieViewModel detailsSerie { get; set; }

		public DetailSeriePage(string id)
		{
			_database = new MovieOrSerieIsFavDataBase ();

			string queryString = "https://api-v2launch.trakt.tv/shows/" + id + "?extended=full,images";

			Image favImage = new Image();

			MovieOrSerieIsFav a = _database.GetData (id);

			int Favori = 0;

			ImageCell imageFavoris = new ImageCell
			{
				ImageSource = favImage.Source,
			};

			if (a != null) 
			{
				Favori = 1;
				imageFavoris.ImageSource = "etoileOn.png";
			} 
			else 
			{
				Favori = 0;
				imageFavoris.ImageSource = "etoileOff.png";
			}

			detailsSerie = Core.GetSerieDetails(queryString);

			string urlImdb = "http://www.imdb.com/title/" + detailsSerie.Imdb + "/?ref_=fn_al_tt_1";

			var webImage = new Image { Aspect = Aspect.AspectFit };
			if (detailsSerie.UrlImage != null)
			{
				webImage.Source = ImageSource.FromUri (new Uri (detailsSerie.UrlImage));
			} 
			else 
			{
				webImage.Source = ImageSource.FromUri (new Uri ("http://sd.keepcalm-o-matic.co.uk/i/error-404-democracy-not-found.png"));
			}

			string translation;

			if(detailsSerie.AvailableTranslation == "[]")
			{
				translation = "not avaiable";
			}
			else
			{
				translation = detailsSerie.AvailableTranslation.Replace ("\n", "").Replace ("[ ", "").Replace ("]", "");
			}

			TextCell redirectImdb = new TextCell
			{
				Text = "imdb",
				Detail = "Go on imdb.com"
			};

			if (detailsSerie.Imdb != null && detailsSerie.Imdb != "") 
			{
				redirectImdb.Tapped += (s, e) => {
					Device.OpenUri (new Uri (urlImdb));
				};
			}
			else 
			{
				redirectImdb.Detail = "No imdb";
			}

			TextCell redirectToYoutubeTrailer = new TextCell
			{
				Text = "Trailer",
				Detail = "Go on youtube trailer"
			};

			if (detailsSerie.Imdb != null && detailsSerie.Imdb != "") 
			{
				redirectToYoutubeTrailer.Tapped += (s, e) => {
					Device.OpenUri(new Uri(detailsSerie.UrlTrailer));
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
					new TableSection(detailsSerie.Title +' '+ detailsSerie.Year+" ("+detailsSerie.Language+") "+detailsSerie.Certification)
					{
						imageFavoris,

						new ImageCell
						{
							ImageSource = webImage.Source,
						},

						new TextCell
						{
							Text = "Certification",
							Detail = detailsSerie.Certification,
						},

						new TextCell
						{
							Text = "Year",
							Detail = detailsSerie.Year.ToString(),
						},

						new TextCell
						{
							Text = "Language",
							Detail = detailsSerie.Language,
						},

						new TextCell
						{
							Text = "Country",
							Detail = detailsSerie.Country,
						},

						new TextCell
						{
							Text = "Gender",
							Detail = detailsSerie.Gender.Replace("\n","").Replace("[ ","").Replace("]",""),
						},

						new TextCell
						{
							Text = "Rating ("+detailsSerie.Vote+" votes)",
							Detail = detailsSerie.Rating.ToString(),
						},

						new TextCell
						{
							Text = "Runtime",
							Detail = detailsSerie.Runtime.ToString(),
						},

						new TextCell
						{
							Text = "Available Translation",
							Detail = translation,
						},

						redirectImdb,
						redirectToYoutubeTrailer,

						new TextCell
						{
							Text = "Overview ",
						},

						new TextCell
						{
							Text = detailsSerie.OverView,
						},
					},
				}
			};

			layout.Children.Add(sect1);

			imageFavoris.Tapped += (s, e) =>
			{
				if (Favori != 1)
				{
					Favori = 1;
					layout.Children.Remove(sect1);
					imageFavoris.ImageSource = "etoileOn.png";
					layout.Children.Add(sect1);
					_database.AddData(id, detailsSerie.Title + "\n\n(show)", detailsSerie.UrlImage, "show");
				}
				else
				{
					Favori = 0;
					layout.Children.Remove(sect1);
					imageFavoris.ImageSource = "etoileOff.png";
					layout.Children.Add(sect1);
					_database.DeleteData(id);
				}
			};

			Content = layout;
		}
	}
}