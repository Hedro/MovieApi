using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

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
	}
}