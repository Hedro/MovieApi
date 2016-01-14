using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Xamarin.Forms;

namespace MovieApi
{
	public class ItemViewModel : ContentPage
	{
		public string Identifiant { get; set; }
		public string Name { get; set; }

		[JsonProperty(PropertyName = "type")]
		public string Type { get; set; }
		public string Year { get; set; }
		public string URLImage { get; set; }

		public ImageSource Image { get; set; }

		public ItemViewModel ()
		{
			
		}
	}
}


