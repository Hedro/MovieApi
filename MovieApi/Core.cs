using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace MovieApi
{
	public class Core
	{
		public static async Task<dynamic> GetMovie()
		{
			string queryString = "https://api-v2launch.trakt.tv/movies/trending?extended=images";
			dynamic results = await DataServices.getDataFromService(queryString).ConfigureAwait(false);

			return results;
		}
	}
}