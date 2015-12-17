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
		}

		public class CustomMovieCell : ViewCell
		{
			public CustomMovieCell()
			{
				AbsoluteLayout cellView = new AbsoluteLayout (){};

				var nameLabel = new Label ();
				nameLabel.SetBinding (Label.TextProperty, new Binding ("Name"));
				AbsoluteLayout.SetLayoutBounds (nameLabel,new Rectangle(.25, .25, 400, 40));
				nameLabel.FontSize = 24;
				cellView.Children.Add (nameLabel);

				var typeLabel = new Label ();
				typeLabel.SetBinding (Label.TextProperty, new Binding ("Type"));
				AbsoluteLayout.SetLayoutBounds (typeLabel,new Rectangle(50, 35, 200, 25));
				cellView.Children.Add (typeLabel);

				var image = new Image ();
				image.SetBinding (Image.SourceProperty, new Binding ("Image"));
				AbsoluteLayout.SetLayoutBounds (image,new Rectangle(250, .25, 200, 25));
				cellView.Children.Add (image);
				this.View = cellView;
			}
		}

		public void getMovies()
		{
			movies.Add (new MovieViewModel{ Name="Batman", Type="Action", Image="aaa.png"});
			movies.Add (new MovieViewModel{ Name="Inglorious Bastard", Type="Action", Image=""});
			movies.Add (new MovieViewModel{ Name="Shutter Island", Type="Thriller", Image=""});
		}
	}
}


