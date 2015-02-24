using System;

using Xamarin.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace GeStock
{
	public class StockPage : ContentPage
	{
		ObservableCollection<GeStockItem> _myItems;

		public StockPage ()
		{
			Title = "Stock";

			ListView listView = new ListView {
				RowHeight = 40,
				ItemTemplate = new DataTemplate(typeof(GeStockItemCell))
			};

			_myItems = new ObservableCollection<GeStockItem>();

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

				var produit = new ProductXAML (geStockItem);
				Navigation.PushAsync(produit);
			};

			MessagingCenter.Subscribe<ListView, GeStockItem> (listView, "deleteItemCell", (sender, arg) => {

				_myItems.Remove(arg);
			});
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
