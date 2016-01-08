using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

using Newtonsoft.Json;

namespace MovieApi
{
	public class DataServices
	{
		public static string getMovieDataFromService(string queryString)
		{
			
			HttpRequestMessage request = new HttpRequestMessage (HttpMethod.Get, queryString);

			request.Headers.Add ("trakt-api-version", "2");
			request.Headers.Add ("trakt-api-key", "307a0050e092fa43ade770a7fb96dce78383d027cef998105bd5f41b5158659d");

			HttpClient httpClient = new HttpClient ();

			HttpResponseMessage httpResponse = httpClient.SendAsync (request).Result;

			string responseText = httpResponse.Content.ReadAsStringAsync ().Result;

			return responseText;
		}

		public static string getSerieDataFromService(string queryString)
		{

			HttpRequestMessage request = new HttpRequestMessage (HttpMethod.Get, queryString);

			request.Headers.Add ("trakt-api-version", "2");
			request.Headers.Add ("trakt-api-key", "307a0050e092fa43ade770a7fb96dce78383d027cef998105bd5f41b5158659d");

			HttpClient httpClient = new HttpClient ();

			HttpResponseMessage httpResponse = httpClient.SendAsync (request).Result;

			string responseText = httpResponse.Content.ReadAsStringAsync ().Result;

			return responseText;
		}
	}
}

