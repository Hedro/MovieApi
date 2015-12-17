using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace MovieApi
{
	public class MoviePage : ContentPage
	{
		public ObservableCollection<MovieViewModel> movies { get; set; }

		public MoviePage ()
		{
			movies = new ObservableCollection<MovieViewModel> ();
			ListView listView = new ListView ();

			listView.RowHeight = 100;

			this.Title = "Top 10 Movies";

			listView.ItemsSource = movies;
			listView.ItemTemplate = new DataTemplate (typeof(CustomMovieCell));

			Content = listView;

			getMovies ();

			//Evenement OnClick
			listView.ItemSelected += async (sender, e) => {
				if (e.SelectedItem == null)
				{
					return;
				}
				//Deselect row
				listView.SelectedItem= null;

				await Navigation.PushModalAsync (new DetailMoviePage());
			};
		}

		public class CustomMovieCell : ViewCell
		{
			public CustomMovieCell()
			{
				StackLayout cellView = new StackLayout (){};

				cellView.Orientation = StackOrientation.Horizontal;
				StackLayout cellWrapper = new StackLayout ();

				//Set Labels et Image
				var image = new Image ();
				var nameLabel = new Label ();
				var yearLabel = new Label ();

				//Set bindings
				nameLabel.SetBinding (Label.TextProperty, "Name");
				yearLabel.SetBinding (Label.TextProperty, "Year");
				image.SetBinding (Image.SourceProperty, "Image");

				//Add to cells
				cellView.Children.Add (image);
				cellView.Children.Add (nameLabel);
				cellView.Children.Add (yearLabel);
				cellWrapper.Children.Add (cellView);
				View = cellWrapper;
			}
		}

		public void getMovies()
		{
			movies.Add (new MovieViewModel{ Name="Batman", Year="2000", Image=""});
			movies.Add (new MovieViewModel{ Name="Inglorious Bastard", Year="2001", Image=""});
			movies.Add (new MovieViewModel{ Name="Shutter Island", Year="2008", Image=""});
		}
	}
}