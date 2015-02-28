using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;

namespace GeStock {

	public partial class EditProductXAML : ContentPage {

		bool _saved = false;

		GeStockItemViewModel _geStockItemViewModel;
		GeStockItem _geStockItemOriginal;

		public EditProductXAML (GeStockItemViewModel geStockItemViewModel) {

			_geStockItemOriginal = new GeStockItem (geStockItemViewModel.StockItem);

			_geStockItemViewModel = geStockItemViewModel;

			BindingContext = _geStockItemViewModel;

			InitializeComponent ();
		}

		override protected void OnDisappearing() {
			base.OnDisappearing();

			if (!_saved)
				_geStockItemViewModel.Restore (_geStockItemOriginal);
		}

		void SaveAndComeBack(object sender, EventArgs e) {

			_geStockItemViewModel.Save ();
			_saved = true;

			Navigation.PopAsync ();
		}
	}
}

