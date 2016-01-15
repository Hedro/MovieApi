using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using MovieApi.Model;

namespace MovieApi
{
	public class Core
	{
		public static MovieViewModel[] GetMovie(string queryString)
		{
			string results = DataServices.getDataFromService(queryString);

			if (results != null) 
			{
				dynamic data = JsonConvert.DeserializeObject(results);

				MovieViewModel[] movieViewModel = new MovieViewModel[10];

				for (int i = 0; i < 10; i++) 
				{
					movieViewModel[i] = new MovieViewModel ();

					movieViewModel[i].Identifiant = (string)data[i]["movie"]["ids"]["slug"].Value;
					movieViewModel[i].Name = (string)data[i]["movie"]["title"].Value;
					movieViewModel[i].Year = (long)data[i]["movie"]["year"].Value;
					movieViewModel[i].URLImage = (string)data[i]["movie"]["images"]["poster"]["thumb"].Value;
				}

				return movieViewModel;
			} 
			else 
			{
				return null;
			}
		}

		public static SerieViewModel[] GetSerie(string queryString)
		{
			string results = DataServices.getDataFromService(queryString);

			if (results != null) 
			{
				dynamic data = JsonConvert.DeserializeObject(results);

				SerieViewModel[] serieViewModel = new SerieViewModel[10];

				for (int i = 0; i < 10; i++) 
				{
					serieViewModel[i] = new SerieViewModel ();

					serieViewModel[i].Identifiant = (string)data[i]["show"]["ids"]["slug"].Value;
					serieViewModel[i].Name = (string)data[i]["show"]["title"].Value;
					serieViewModel[i].Year = (long)data[i]["show"]["year"].Value;
					serieViewModel[i].URLImage = (string)data[i]["show"]["images"]["poster"]["thumb"].Value;
				}

				return serieViewModel;
			} 
			else 
			{
				return null;
			}
		}

		public static ItemViewModel[] GetItem(string queryString)
		{
			string results = DataServices.getDataFromService(queryString);

			int j;

			if (results != null && results != "[]") 
			{
				var data1 = JsonConvert.DeserializeObject<List<ItemViewModel>>(results);

				dynamic data = JsonConvert.DeserializeObject(results);

				ItemViewModel[] itemViewModel = new ItemViewModel[10];

				if (data1.Count < 10) 
				{
					j = data1.Count;
				} 
				else 
				{
					j = 10;
				}

				for (int i = 0; i<j ; i++)
				{
					itemViewModel[i] = new ItemViewModel ();

					itemViewModel[i].Type = (string)data[i]["type"].Value;
					itemViewModel[i].Identifiant = (string)data[i][itemViewModel[i].Type]["ids"]["slug"].Value;
					itemViewModel[i].Name = (string)data[i][itemViewModel[i].Type]["title"].Value;
					if (data [i] [itemViewModel [i].Type] ["year"].Value == null)
					{
						itemViewModel [i].Year = "n/a";
					} 
					else
					{
						itemViewModel [i].Year = data [i] [itemViewModel [i].Type] ["year"].Value.ToString ();
					}
					itemViewModel[i].URLImage = (string)data[i][itemViewModel[i].Type]["images"]["poster"]["thumb"].Value;
				}

				return itemViewModel;
			} 
			else 
			{
				return null;
			}
		}

		public static DetailsMovieViewModel GetMovieDetails(string queryString)
		{
			string results = DataServices.getDataFromService(queryString);

			DetailsMovieViewModel movieDetailViewModel = new DetailsMovieViewModel();

			dynamic data = JsonConvert.DeserializeObject(results);

			movieDetailViewModel.Imdb = (string)data["ids"]["imdb"].Value;;
			movieDetailViewModel.OverView = (string)data["overview"].Value;
			movieDetailViewModel.Title = (string)data["title"].Value;
			movieDetailViewModel.UrlImage = (string)data["images"]["poster"]["thumb"].Value;
			movieDetailViewModel.Released = (string)data["released"].Value;
			movieDetailViewModel.Year = (long)data["year"].Value;
			movieDetailViewModel.Certification = (string)data["certification"].Value;
			movieDetailViewModel.Vote = (long)data["votes"].Value;
			movieDetailViewModel.Tagline = (string)data["tagline"].Value;
			movieDetailViewModel.UrlTrailer = (string)data["trailer"].Value;
			movieDetailViewModel.Rating = (long)data["rating"].Value;
			movieDetailViewModel.Language = (string)data["language"].Value;

			return movieDetailViewModel;
		}

		public static DetailsSerieViewModel GetSerieDetails(string queryString)
		{
			string results = DataServices.getDataFromService(queryString);

			DetailsSerieViewModel serieDetailViewModel = new DetailsSerieViewModel();

			dynamic data = JsonConvert.DeserializeObject(results);

			serieDetailViewModel.OverView = (string)data["overview"].Value;
			serieDetailViewModel.Title = (string)data["title"].Value;
			serieDetailViewModel.UrlImage = (string)data["images"]["poster"]["thumb"].Value;
			serieDetailViewModel.Imdb = (string)data["ids"]["imdb"].Value;
			serieDetailViewModel.Runtime = (long)data["runtime"].Value;
			serieDetailViewModel.AvailableTranslation = (string)data["available_translations"].ToString();
			serieDetailViewModel.Gender = (string)data["genres"].ToString();
			serieDetailViewModel.Year = (long)data["year"].Value;
			serieDetailViewModel.Country = (string)data["country"].Value;
			serieDetailViewModel.Certification = (string)data["certification"].Value;
			serieDetailViewModel.Vote = (long)data["votes"].Value;
			serieDetailViewModel.UrlTrailer = (string)data["trailer"].Value;
			serieDetailViewModel.Rating = (long)data["rating"].Value;
			serieDetailViewModel.Language = (string)data["language"].Value;

			return serieDetailViewModel;
		}
	}
}