using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Linq;
using System.Diagnostics;

namespace GeStock {
	public partial class EditControlKitXAML : ContentPage {

		bool _saved = false;

		ControlKitViewModel _controlKitViewModel;
		ControlKit _controlKitOriginal;

		IEnumerable<GeStockItem> products;

		ObservableCollection<GeStockItem> _myItems;

		double quantity = 1;
		
		public EditControlKitXAML (ControlKitViewModel controlKitViewModel)
		{
			_controlKitOriginal = new ControlKit (controlKitViewModel.ControlKit);

			_controlKitViewModel = controlKitViewModel;

			InitializeComponent ();

			products = App.Database.GetItems ();
			foreach (GeStockItem product in products)
				ProductPicker.Items.Add (product.Name);

			ProductPicker.SelectedIndex = 0;

			StepperQuantity.Value = quantity;
			LabelQuantity.Text = quantity.ToString();

			GeStockItemCell.showDelete = true;

			_myItems = new ObservableCollection<GeStockItem>();
			ObjectsList.ItemsSource = _myItems;
			ObjectsList.ItemTemplate = new DataTemplate (typeof(GeStockItemCell));

			dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject (_controlKitViewModel.Elements);

			foreach (var property in json) {

				GeStockItem item = App.Database.GetItem (Convert.ToUInt16((string) property.Name));

				item.Quantity = Convert.ToUInt16((string) property.Value);

				_myItems.Add (item);
			}

			MessagingCenter.Subscribe<ListView, GeStockItem> (ObjectsList, "deleteItemCell", (sender, arg) => {
				_myItems.Remove(arg);
			});

			BindingContext = _controlKitViewModel;
		}

		override protected void OnDisappearing() {
			base.OnDisappearing();

			if (!_saved)
				_controlKitViewModel.Restore (_controlKitOriginal);
		}

		void AddProduct(object sender, EventArgs e) {

			string productName = ProductPicker.Items [ProductPicker.SelectedIndex];

			GeStockItem product = products.First (x => x.Name == productName);
			product.Quantity = (int)quantity;

			_myItems.Add (product);
		}

		void QuantityChanged(object sender, EventArgs e) {

			StepperQuantity.Value = quantity = ((Stepper)sender).Value;
			LabelQuantity.Text = quantity.ToString();
		}

		void SaveAndComeBack(object sender, EventArgs e) {

			if (!String.IsNullOrEmpty (_controlKitViewModel.Name) && _myItems.Count > 0) {

				string output = "{";

				for (int i = 0; i < _myItems.Count; ++i) {

					output += "" + _myItems [i].ID + ":" + _myItems [i].Quantity;

					if (i < _myItems.Count - 1)
						output += ",";
				}

				output += "}";

				_controlKitViewModel.Elements = output;

				_controlKitViewModel.Save ();

				_saved = true;
				Navigation.PopAsync ();
			}
		}
	}
}

