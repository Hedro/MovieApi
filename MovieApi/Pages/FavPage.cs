using MovieApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;


namespace MovieApi
{
	public class FavPage : ContentPage
	{
		private MovieOrSerieIsFavDataBase _database;

		public static ListView listView = new ListView ();

		public FavPage ()
		{
			_database = new MovieOrSerieIsFavDataBase ();

			listView.RowHeight = 100;

			listView.ItemsSource = _database.GetDatas ();
			listView.ItemTemplate = new DataTemplate (typeof(CustomItemCell));


			var stack = new StackLayout () 
			{
				Children = 
				{
					listView
				}
			};
			
			Content = stack;

			listView.ItemSelected += async (sender, e) => {

				//Deselect row
				listView.SelectedItem = null;

				MovieOrSerieIsFav a = (MovieOrSerieIsFav) e.SelectedItem;

				if (e.SelectedItem != null)
				{
					if(a.MovieOrSerieType == "movie")
					{
						listView.IsEnabled = false;

						//Ouvre la page de detail
						await Navigation.PushAsync (new DetailMoviePageXaml(a.MovieOrSerieID));

						listView.IsEnabled = true;
					}
					if(a.MovieOrSerieType == "show")
					{
						//Deselect row
						listView.SelectedItem = null;

						listView.IsEnabled = false;

						//Ouvre la page de detail
						await Navigation.PushAsync (new DetailSeriePageXaml(a.MovieOrSerieID));

						listView.IsEnabled = true;
					}
				}
				return;
			};
		}

		protected override void OnAppearing ()
		{
			listView.ItemsSource = _database.GetDatas ();
		}

		public static ListView getListView() 
		{
			return listView;
		}
	}

	public class CustomItemCell : ViewCell
	{
		private MovieOrSerieIsFavDataBase _database;

		public CustomItemCell()
		{
			_database = new MovieOrSerieIsFavDataBase ();

			StackLayout cellView = new StackLayout (){};

			cellView.Orientation = StackOrientation.Horizontal;
			StackLayout cellWrapper = new StackLayout ();

			//Set Labels et Image
			var image = new Image ();
			var nameLabel = new Label ();
			var typeLabel = new Label ();
			var deleteAction = new MenuItem { Text = "Delete", IsDestructive = true };

			//Set bindings
			image.SetBinding (Image.SourceProperty, "MovieOrSerieImageUrl");
			nameLabel.SetBinding (Label.TextProperty, "MovieOrSerieName");
			typeLabel.SetBinding (Label.TextProperty, "\n\n" + "MovieOrSerieType");
			deleteAction.SetBinding (MenuItem.CommandParameterProperty, new Binding ("."));

			deleteAction.Clicked += (sender, e) => {
				var a = (MenuItem)sender;

				MovieOrSerieIsFav movieOrSerieIsFav = (MovieOrSerieIsFav) a.BindingContext;

				_database.DeleteData(movieOrSerieIsFav.MovieOrSerieID);

				FavPage.getListView().ItemsSource = _database.GetDatas();
			};

			image.WidthRequest = 72.0;

			//Add to cells
			cellView.Children.Add (image);
			cellView.Children.Add (nameLabel);
			cellView.Children.Add (typeLabel);
			ContextActions.Add (deleteAction);
			cellWrapper.Children.Add (cellView);
			View = cellWrapper;

			this.View = cellView;
		}
	}
}