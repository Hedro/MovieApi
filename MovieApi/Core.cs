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
	}
}