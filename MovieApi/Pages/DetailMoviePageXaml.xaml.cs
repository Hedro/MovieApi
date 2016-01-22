using System;
using System.Collections.Generic;

using Xamarin.Forms;
using MovieApi.Model;

namespace MovieApi
{
	public partial class DetailMoviePageXaml : ContentPage
	{
		public DetailsMovieViewModel movieDetails { get; set; }

		private MovieOrSerieIsFavDataBase _database;

		public DetailMoviePageXaml (string id)
		{
			InitializeComponent ();

			int Favori = 0;

			string queryString = "https://api-v2launch.trakt.tv/movies/" + id + "?extended=full,images";

			_database = new MovieOrSerieIsFavDataBase ();

			MovieOrSerieIsFav a = _database.GetData (id);

			movieDetails = Core.GetMovieDetails(queryString);

			string urlImdb = "http://www.imdb.com/title/" + movieDetails.Imdb + "/?ref_=fn_al_tt_1";

			if (movieDetails.UrlImage != null) 
			{
				Poster.Source = ImageSource.FromUri (new Uri (movieDetails.UrlImage));
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
					_database.AddData(id, movieDetails.Title + "\n\n(movie)", movieDetails.UrlImage, "movie");
				}
				else
				{
					Favori = 0;
					Fav.Source = ImageSource.FromFile("FavNon.png");
					_database.DeleteData(id);
				}
			};

			Fav.GestureRecognizers.Add(favImageClick);

			Title.Text = movieDetails.Title + "(" + movieDetails.Year + ")";
			Tagline.Text = movieDetails.Tagline;
			Overview.Text = movieDetails.OverView;
			Certification.Text = movieDetails.Certification;
			Released.Text = movieDetails.Released;
			Rating.Text = movieDetails.Rating + "(" + movieDetails.Vote + ")";

			if (movieDetails.Imdb != null && movieDetails.Imdb != "") 
			{
				Imdb.Source = ImageSource.FromFile ("imdbicon.png");
				var imdbLink = new TapGestureRecognizer ();
				imdbLink.Tapped += (sender, e) => {
					Device.OpenUri (new Uri (urlImdb));
				};

				Imdb.GestureRecognizers.Add (imdbLink);
			}

			if (movieDetails.UrlTrailer != null && movieDetails.UrlTrailer != "") 
			{
				Youtube.Source = ImageSource.FromFile("YouTubeIcon.png");
				var youTubeTrailerLink = new TapGestureRecognizer ();
				youTubeTrailerLink.Tapped += (sender, e) => {
					Device.OpenUri (new Uri (movieDetails.UrlTrailer));
				};

				Youtube.GestureRecognizers.Add (youTubeTrailerLink);
			}
		}
	}
}

