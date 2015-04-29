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

			_myItems = new ObservableCollection<GeStockItem>();
			ObjectsList.ItemsSource = _myItems;

			GeStockItemCell.showDelete = false;

			ObjectsList.ItemTemplate = new DataTemplate (typeof(GeStockItemCell));

			dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject (_controlKitViewModel.Elements);

			foreach (var property in json) {

				GeStockItem item = App.Database.GetItem (Convert.ToUInt16((string) property.Name));

				item.Quantity = Convert.ToUInt16((string) property.Value);

				_myItems.Add (item);
			}
		}

		void ShowEditPage(object sender, EventArgs e) {

			//Navigation.PushAsync(new EditProductXAML(_geStockItemViewModel));
		}
	}
}

