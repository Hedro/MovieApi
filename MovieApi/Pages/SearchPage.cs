﻿using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace MovieApi
{
	public class SearchPage : ContentPage
	{
		SearchBar searchbar;

		public ObservableCollection<ItemViewModel> items { get; set; }

		string queryString;

		public SearchPage ()
		{
			items = new ObservableCollection<ItemViewModel> ();

			searchbar = new SearchBar () 
			{
				Placeholder = "Search",
			};

			ListView listView = new ListView ();
			listView.RowHeight = 100;

			searchbar.TextChanged += (sender, e) => {
				if(searchbar.Text != "")
				{
					queryString = "https://api-v2launch.trakt.tv/search?query=" + searchbar.Text + "&type=show,movie&extended=full,images";

					ItemViewModel[] itemViewModel = Core.GetItem (queryString);

					getItems(itemViewModel);

					listView.ItemsSource = items;
					listView.ItemTemplate = new DataTemplate (typeof(CustomItemCell));
				}
				else
				{
					items.Clear();
				}
			};

			var stack = new StackLayout () 
			{
				Children = 
				{
					searchbar,
					listView
				}
			};

			listView.ItemSelected += async (sender, e) => {

				//Deselect row
				listView.SelectedItem = null;

				ItemViewModel a = (ItemViewModel) e.SelectedItem;

				if (e.SelectedItem != null)
				{
					if(a.Type == "movie")
					{
						//Ouvre la page de detail
						await Navigation.PushAsync (new DetailMoviePage(a.Identifiant));
					}
					if(a.Type == "show")
					{
						//Ouvre la page de detail
						await Navigation.PushAsync (new DetailSeriePage(a.Identifiant));
					}
				}
				return;
			};

			Content = stack;
		}

		public class CustomItemCell : ViewCell
		{
			public CustomItemCell()
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

		public void getItems(ItemViewModel[] item)
		{
			items.Clear ();

			if (item != null) 
			{
				for (int i = 0; i < 10; i++) 
				{
					if (item [i] == null) 
					{
						return;
					}

					if (item [i].URLImage == null) 
					{
						item [i].URLImage = "http://sd.keepcalm-o-matic.co.uk/i/error-404-democracy-not-found.png";
					}

					items.Add (new ItemViewModel {
						Identifiant = item [i].Identifiant,
						Name = item [i].Name + "\n\n(" + item [i].Year.ToString () + ")\n" + item[i].Type,
						Type = item[i].Type,
						Image = ImageSource.FromUri (new Uri (item [i].URLImage))
					});
				}
			} 
		}
	}
}