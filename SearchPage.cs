using System;

using Xamarin.Forms;
using SQLite.Net;
using System.Diagnostics;

namespace GeStock
{
	public class SearchPage : ContentPage
	{
		Label _resultsLabel;

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

			Content = new StackLayout { 
				Children = {
					header,
					searchBar,
					new ScrollView {
						Content = _resultsLabel,
						VerticalOptions = LayoutOptions.FillAndExpand
					}
				}
			};

			searchBar.SearchButtonPressed += OnSearchBarButtonPressed;
		}

		void OnSearchBarButtonPressed(object sender, EventArgs args) {

			SearchBar searchBar = (SearchBar)sender;
			string searchText = searchBar.Text;

			_resultsLabel.Text = App.Database.FindItemNamed (searchText).Name;
		}
	}
}
