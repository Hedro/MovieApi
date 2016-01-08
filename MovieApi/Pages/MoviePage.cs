﻿using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace MovieApi
{
	public class MoviePage : ContentPage
	{
		public ObservableCollection<MovieViewModel> movies { get; set; }

		public MoviePage ()
		{
			NavigationPage.SetHasBackButton (this, true);

			movies = new ObservableCollection<MovieViewModel> ();
			ListView listView = new ListView ();

			listView.RowHeight = 100;

			this.Title = "Top 10 Movies";

			listView.ItemsSource = movies;
			listView.ItemTemplate = new DataTemplate (typeof(CustomMovieCell));

			Content = listView;

			//Recupere le top 10 des films dans l'Api
			MovieViewModel[] movieViewModel = Core.GetMovie ();

			getMovies (movieViewModel);

			//Evenement OnClick
			listView.ItemSelected += async (sender, e) => {
				
				if (e.SelectedItem != null)
				{
					//Deselect row
					listView.SelectedItem= null;

					//Ouvre la page de detail
					await Navigation.PushModalAsync (new DetailMoviePage());
				}
				return;
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
			
		public void getMovies(MovieViewModel[] movie)
		{
			if(movie != null)
			{
				for (int i = 0; i < 10; i++) 
				{
					movies.Add (new MovieViewModel{ Identifiant = movie[i].Identifiant, Name = movie[i].Name + "\n\n(" + movie[i].Year.ToString() + ")", Image = ImageSource.FromUri(new Uri(movie[i].URLImage)) });
				}
			}
		}
	}
}