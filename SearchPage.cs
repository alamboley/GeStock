using System;

using Xamarin.Forms;
using SQLite.Net;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GeStock
{
	public class SearchPage : ContentPage
	{
		Label _resultsLabel;

		ObservableCollection<GeStockItem> _myItems;

		public SearchPage ()
		{
			Title = "Rechercher";

			Label header = new Label {

				Text = "Chercher un produit",
				HorizontalOptions = LayoutOptions.Center
			};

			SearchBar searchBar = new SearchBar {
				Placeholder = "mon produit"
			};

			_resultsLabel = new Label ();

			ListView listView = new ListView {
				RowHeight = 40,
				ItemTemplate = new DataTemplate(typeof(GeStockItemCell))
			};

			_myItems = new ObservableCollection<GeStockItem>();
			listView.ItemsSource = _myItems;

			Content = new StackLayout { 
				Children = {
					new Label { HorizontalOptions = LayoutOptions.Center },
					listView
				}
			};

			listView.ItemSelected += (sender, e) => {

				GeStockItem geStockItem = (GeStockItem)e.SelectedItem;

				Navigation.PushAsync(new ProductXAML (geStockItem));
			};

			Content = new StackLayout { 
				Children = {
					header,
					searchBar,
					listView
				}
			};

			searchBar.TextChanged += OnSearchBarButtonPressed;
			//searchBar.SearchButtonPressed += OnSearchBarButtonPressed;
		}

		void OnSearchBarButtonPressed(object sender, EventArgs args) {

			SearchBar searchBar = (SearchBar)sender;
			string searchText = searchBar.Text;

			List<GeStockItem> items = App.Database.FindItemsCloseToName(searchText);

			_myItems.Clear();

			foreach (GeStockItem gestockItem in items)
				_myItems.Add (gestockItem);
		}
	}
}
