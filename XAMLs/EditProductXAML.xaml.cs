using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;

namespace GeStock {

	public partial class EditProductXAML : ContentPage {

		bool _saved = false;

		GeStockItemViewModel _geStockItemViewModel;
		GeStockItemViewModel _geStockItemViewModelOriginal;

		public EditProductXAML (GeStockItemViewModel geStockItemViewModel) {

			_geStockItemViewModelOriginal = geStockItemViewModel;
			_geStockItemViewModel = geStockItemViewModel;

			BindingContext = _geStockItemViewModel;

			InitializeComponent ();
		}

		override protected void OnDisappearing() {
			base.OnDisappearing();

			if (!_saved)
				_geStockItemViewModel = _geStockItemViewModelOriginal;

			Debug.WriteLine (_geStockItemViewModel.Quantity + " ------ " + _geStockItemViewModelOriginal.Quantity);
		}

		void SaveAndComeBack(object sender, EventArgs e) {

			_geStockItemViewModel.Save ();
			_saved = true;

			Navigation.PopAsync ();
		}
	}
}

