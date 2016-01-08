using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using MovieApi;

namespace SerieApi
{
	public class SeriePage : ContentPage
	{
		public ObservableCollection<SerieViewModel> series { get; set; }

		public SeriePage ()
		{
			series = new ObservableCollection<SerieViewModel> ();
			ListView listView = new ListView ();

			listView.RowHeight = 100;

			this.Title = "Top 10 Series";

			listView.ItemsSource = series;
			listView.ItemTemplate = new DataTemplate (typeof(CustomSerieCell));

			Content = listView;

			//Recupere le top 10 des films dans l'Api
			SerieViewModel[] serieViewModel = Core.GetSerie ();

			getSeries (serieViewModel);

			//Evenement OnClick
			listView.ItemSelected += async (sender, e) => {

				if (e.SelectedItem != null)
				{
					//Deselect row
					listView.SelectedItem= null;

					//Ouvre la page de detail
					await Navigation.PushModalAsync (new DetailSeriePage());
				}
				return;
			};
		}

		public class CustomSerieCell : ViewCell
		{
			public CustomSerieCell()
			{
				StackLayout cellView = new StackLayout (){};

				cellView.Orientation = StackOrientation.Horizontal;
				StackLayout cellWrapper = new StackLayout ();

				//Set Labels et Image
				var image = new Image ();
				var nameLabel = new Label ();

				//Set bindings
				image.SetBinding (Image.SourceProperty, "Image");
				nameLabel.SetBinding (Label.TextProperty, "Name");

				image.WidthRequest = 72.0;

				//Add to cells
				cellView.Children.Add (image);
				cellView.Children.Add (nameLabel);
				cellWrapper.Children.Add (cellView);
				View = cellWrapper;

				this.View = cellView;
			}
		}

		public void getSeries(SerieViewModel[] serie)
		{
			if(serie != null)
			{
				for (int i = 0; i < 10; i++) 
				{
					series.Add (new SerieViewModel{ Identifiant = serie[i].Identifiant, Name = serie[i].Name + "\n\n(" + serie[i].Year.ToString() + ")", Image = ImageSource.FromUri(new Uri(serie[i].URLImage)) });
				}
			}
		}
	}
}


