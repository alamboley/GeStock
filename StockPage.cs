using System;

using Xamarin.Forms;
using System.Collections.Generic;
using System.Diagnostics;

namespace GeStock
{
	public class StockPage : ContentPage
	{
		List<GeStockItem> _myItems;

		public StockPage ()
		{
			Title = "Stock";

			ListView listView = new ListView {
				RowHeight = 40,
				ItemTemplate = new DataTemplate(typeof(GeStockItemCell))
			};

			_myItems = new List<GeStockItem>();

			_refreshList();

			listView.ItemsSource = _myItems;

			Content = new StackLayout { 
				Children = {
					new Label { Text = "Stock", HorizontalOptions = LayoutOptions.Center },
					listView
				}
			};

			listView.ItemSelected += (sender, e) => {

				GeStockItem geStockItem = (GeStockItem)e.SelectedItem;

				Debug.WriteLine (geStockItem.Name);

				var produit = new ProductXAML ();
				Navigation.PushAsync(produit);
			};
		}

		override protected void OnAppearing() {
			base.OnAppearing();

			_refreshList();
		}

		void _refreshList() {

			_myItems.Clear();

			var items = App.Database.GetItems();

			foreach (GeStockItem gestockItem in items)
				_myItems.Add (gestockItem);
		}
	}
}
