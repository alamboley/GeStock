
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;
using System.Linq;

namespace GeStock {

	public partial class NewProductXAML : ContentPage {

		GeStockItemViewModel stockItemMV;

		IEnumerable<Category> categories;

		public NewProductXAML () {
		
			InitializeComponent ();

			categories = App.Database.GetCategories ();

			foreach (Category category in categories)
				CategoryPicker.Items.Add (category.Name);

			CategoryPicker.SelectedIndex = 0;

			NewProduct ();
		}

		void NewProduct() {

			stockItemMV = new GeStockItemViewModel(new GeStockItem());

			BindingContext = stockItemMV;
		}

		void SaveAndNewProduct(object sender, EventArgs e) {

			if (!String.IsNullOrEmpty (stockItemMV.Name)) {

				stockItemMV.Category = CategoryPicker.Items [CategoryPicker.SelectedIndex];

				Category category = categories.First (x => x.Name == stockItemMV.Category);

				stockItemMV.CategoryIndex = category.ID;

				stockItemMV.Save ();

				NewProduct ();

			} else
				DisplayAlert ("Attention", "Vous devez entrer un nom pour le produit !", "Ok");
		}
	}
}

