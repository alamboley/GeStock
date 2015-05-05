using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;
using System.Linq;
using System.Collections.ObjectModel;

namespace GeStock {
	public partial class NewControlKitXAML : ContentPage {

		ControlKitViewModel controlKitMV;
		IEnumerable<GeStockItem> products;

		ObservableCollection<GeStockItem> _myItems;

		double quantity = 1;

		public NewControlKitXAML ()
		{
			InitializeComponent ();

			products = App.Database.GetItems ();
			foreach (GeStockItem product in products)
				ProductPicker.Items.Add (product.Name);

			ProductPicker.SelectedIndex = 0;

			StepperQuantity.Value = quantity;
			LabelQuantity.Text = quantity.ToString();

			_myItems = new ObservableCollection<GeStockItem>();
			ObjectsList.ItemsSource = _myItems;
			ObjectsList.ItemTemplate = new DataTemplate (typeof(GeStockItemCell));

			GeStockItemCell.showDelete = true;
			GeStockItemCell.IdMessage = "deleteProductFromNewControlKit";

			MessagingCenter.Subscribe<ListView, GeStockItem> (ObjectsList, "deleteProductFromNewControlKit", (sender, arg) => {
				_myItems.Remove(arg);
			});

			NewControlKit ();
		}

		void NewControlKit() {

			controlKitMV = new ControlKitViewModel (new ControlKit ());

			BindingContext = controlKitMV;

			_myItems.Clear ();
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

		void SaveAndNewControlKit(object sender, EventArgs e) {

			if (!String.IsNullOrEmpty (controlKitMV.Name) && _myItems.Count > 0) {
				
				string output = "{";

				for (int i = 0; i < _myItems.Count; ++i) {

					output += "" + _myItems [i].ID + ":" + _myItems [i].Quantity;

					if (i < _myItems.Count - 1)
						output += ",";
				}

				output += "}";

				controlKitMV.Elements = output;

				controlKitMV.Save ();

				NewControlKit ();

			} else
				DisplayAlert ("Attention", "Vous devez entrer un nom pour le kit de commande et sélectionner au moins un produit !", "Ok");
		}
	}
}

