using System;
using System.Collections.Generic;

using Xamarin.Forms;
using MovieApi.Model;

namespace MovieApi
{
	public partial class DetailSeriePageXaml : ContentPage
	{
		private MovieOrSerieIsFavDataBase _database;

		public DetailsSerieViewModel detailsSerie { get; set; }

		public DetailSeriePageXaml (string id)
		{
			InitializeComponent ();

			int Favori = 0;

			string queryString = "https://api-v2launch.trakt.tv/shows/" + id + "?extended=full,images";

			_database = new MovieOrSerieIsFavDataBase ();

			MovieOrSerieIsFav a = _database.GetData (id);

			detailsSerie = Core.GetSerieDetails(queryString);

			string urlImdb = "http://www.imdb.com/title/" + detailsSerie.Imdb + "/?ref_=fn_al_tt_1";

			if (detailsSerie.UrlImage != null) 
			{
				Poster.Source = ImageSource.FromUri (new Uri (detailsSerie.UrlImage));
			} 
			else 
			{
				Poster.Source = ImageSource.FromUri (new Uri ("http://sd.keepcalm-o-matic.co.uk/i/error-404-democracy-not-found.png"));
			}

			if (a != null) 
			{
				Favori = 1;
				Fav.Source = ImageSource.FromFile("FavOui.png");
			} 
			else 
			{
				Fav.Source = ImageSource.FromFile("FavNon.png");
			}

			var favImageClick = new TapGestureRecognizer ();
			favImageClick.Tapped += (sender, e) => {
				if (Favori != 1)
				{
					Favori = 1;
					Fav.Source = ImageSource.FromFile("FavOui.png");
					_database.AddData(id, detailsSerie.Title + "\n\n(movie)", detailsSerie.UrlImage, "movie");
				}
				else
				{
					Favori = 0;
					Fav.Source = ImageSource.FromFile("FavNon.png");
					_database.DeleteData(id);
				}
			};

			Fav.GestureRecognizers.Add(favImageClick);
				
			Title.Text = detailsSerie.Title + "(" + detailsSerie.Year + ")";
			Overview.Text = detailsSerie.OverView;
			Certification.Text = detailsSerie.Certification;
			Runtime.Text = detailsSerie.Runtime.ToString();
			Genders.Text = detailsSerie.Gender.Replace("\n","").Replace("[ ","").Replace("]","");
			Country.Text = detailsSerie.Country;

			if(detailsSerie.AvailableTranslation == "[]")
			{
				AvailableTranslation.Text = "not avaiable";
			}
			else
			{
				AvailableTranslation.Text = detailsSerie.AvailableTranslation.Replace ("\n", "").Replace ("[ ", "").Replace ("]", "");
			}

			Rating.Text = detailsSerie.Rating + "(" + detailsSerie.Vote + ")";

			if (detailsSerie.Imdb != null && detailsSerie.Imdb != "") 
			{
				Imdb.Source = ImageSource.FromFile ("imdbicon.png");
				var imdbLink = new TapGestureRecognizer ();
				imdbLink.Tapped += (sender, e) => {
					Device.OpenUri (new Uri (urlImdb));
				};

				Imdb.GestureRecognizers.Add (imdbLink);
			}

			if (detailsSerie.UrlTrailer != null && detailsSerie.UrlTrailer != "") 
			{
				Youtube.Source = ImageSource.FromFile("YouTubeIcon.png");
				var youTubeTrailerLink = new TapGestureRecognizer ();
				youTubeTrailerLink.Tapped += (sender, e) => {
					Device.OpenUri (new Uri (detailsSerie.UrlTrailer));
				};

				Youtube.GestureRecognizers.Add (youTubeTrailerLink);
			}
		}
	}
}

