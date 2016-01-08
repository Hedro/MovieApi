using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MovieApi
{
	public class Core
	{
		public static MovieViewModel[] GetMovie()
		{
			string queryString = "https://api-v2launch.trakt.tv/movies/trending?extended=images";
			string results = DataServices.getMovieDataFromService(queryString);

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

		public static SerieViewModel[] GetSerie()
		{
			string queryString = "https://api-v2launch.trakt.tv/shows/trending?extended=images";
			string results = DataServices.getSerieDataFromService(queryString);

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
	}
}