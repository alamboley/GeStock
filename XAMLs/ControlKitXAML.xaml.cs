using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace GeStock {
	
	public partial class ControlKitXAML : ContentPage {

		ControlKitViewModel _controlKitViewModel;

		ObservableCollection<GeStockItem> _myItems;

		public ControlKitXAML (ControlKit controlKit)
		{
			_controlKitViewModel = new ControlKitViewModel (controlKit);

			BindingContext = _controlKitViewModel;

			InitializeComponent ();
		}

		void ShowEditPage(object sender, EventArgs e) {

			Navigation.PushAsync(new EditControlKitXAML(_controlKitViewModel));
		}

		override protected void OnAppearing() {
			base.OnAppearing();

			_refresh();
		}

		void _refresh() {

			_myItems = new ObservableCollection<GeStockItem>();
			ObjectsList.ItemsSource = _myItems;

			GeStockItemCell.showDelete = false;

			ObjectsList.ItemTemplate = new DataTemplate (typeof(GeStockItemCell));

			dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject (_controlKitViewModel.Elements);

			foreach (var property in json) {

				GeStockItem item = App.Database.GetItem (Convert.ToUInt16((string) property.Name));

				int quantity = Convert.ToUInt16((string) property.Value);

				GeStockItemCell._useRedBG = quantity >= item.Quantity;

				item.Quantity = quantity;

				_myItems.Add (item);
			}

			GeStockItemCell._useRedBG = false;
		}
	}
}

