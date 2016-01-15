using MovieApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MovieApi
{
	public class DetailSeriePage : ContentPage
	{
		public DetailsSerieViewModel detailsSerie { get; set; }

		public DetailSeriePage(string id)
		{
			string queryString = "https://api-v2launch.trakt.tv/shows/" + id + "?extended=full,images";

			detailsSerie = Core.GetSerieDetails(queryString);

			string urlImdb = "http://www.imdb.com/title/" + detailsSerie.Imdb + "/?ref_=fn_al_tt_1";

			var webImage = new Image { Aspect = Aspect.AspectFit };
			webImage.Source = ImageSource.FromUri(new Uri(detailsSerie.UrlImage));

			TextCell redirectImdb = new TextCell
			{
				Text = "imdb",
				Detail = "Go on imdb.com"
			};

			redirectImdb.Tapped += (s, e) => {
				Device.OpenUri(new Uri(urlImdb));
			};

			TextCell redirectToYoutubeTrailer = new TextCell
			{
				Text = "Trailer",
				Detail = "Go on youtube trailer"
			};

			redirectToYoutubeTrailer.Tapped += (s, e) => {
				Device.OpenUri(new Uri(detailsSerie.UrlTrailer));
			};

			var layout = new StackLayout
			{

			};

			Grid grid = new Grid
			{
				VerticalOptions = LayoutOptions.FillAndExpand,
				HeightRequest = 150,

				ColumnDefinitions =
				{
					new ColumnDefinition {Width = new GridLength(.1, GridUnitType.Star)},
				}
			};
			
			grid.Children.Add(new Label { Text = detailsSerie.OverView }, 0, 4, 0, 1);

			var sect1 = new TableView
			{
				Root = new TableRoot("Table Title")
				{
					new TableSection(detailsSerie.Title +' '+ detailsSerie.Year+" ("+detailsSerie.Language+") "+detailsSerie.Certification)
					{
						new ImageCell
						{

							ImageSource = webImage.Source,
							Detail = "Runtime: "+detailsSerie.Runtime,
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
							Detail = detailsSerie.AvailableTranslation.Replace("\n", "").Replace("[ ", "").Replace("]",""),
						},

						redirectImdb,
						redirectToYoutubeTrailer,
						new TextCell
						{
							Text = "Overview",
						},
					},
				}
			};

			layout.Children.Add(sect1);
			layout.Children.Add(grid);

			Content = layout;
		}
	}
}