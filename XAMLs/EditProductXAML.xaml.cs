﻿using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using System.Diagnostics;

namespace GeStock {

	public partial class EditProductXAML : ContentPage {

		bool _saved = false;

		GeStockItemViewModel _geStockItemViewModel;
		GeStockItem _geStockItemOriginal;

		IEnumerable<Category> categories;

		public EditProductXAML (GeStockItemViewModel geStockItemViewModel) {

			_geStockItemOriginal = new GeStockItem (geStockItemViewModel.StockItem);

			_geStockItemViewModel = geStockItemViewModel;

			BindingContext = _geStockItemViewModel;

			InitializeComponent ();

			categories = App.Database.GetCategories ();

			foreach (Category category in categories)
				CategoryPicker.Items.Add (category.Name);
		}

		override protected void OnDisappearing() {
			base.OnDisappearing();

			if (!_saved)
				_geStockItemViewModel.Restore (_geStockItemOriginal);
		}

		void SaveAndComeBack(object sender, EventArgs e) {

			if (CategoryPicker.SelectedIndex != -1) {

				_geStockItemViewModel.Category = CategoryPicker.Items [CategoryPicker.SelectedIndex];

				Category category = categories.First (x => x.Name == _geStockItemViewModel.Category);

				_geStockItemViewModel.CategoryIndex = category.ID;
			}

			_geStockItemViewModel.Save ();
			_saved = true;

			Navigation.PopAsync ();
		}
	}
}

