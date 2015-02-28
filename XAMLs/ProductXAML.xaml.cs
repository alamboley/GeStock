using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;

namespace GeStock {

	public partial class ProductXAML : ContentPage {

		GeStockItemViewModel _geStockItemViewModel;

		public ProductXAML (GeStockItem geStockItem)
		{
			_geStockItemViewModel = new GeStockItemViewModel( geStockItem);

			BindingContext = _geStockItemViewModel;

			InitializeComponent ();
		}

		void ShowEditPage(object sender, EventArgs e) {

			Navigation.PushAsync(new EditProductXAML(_geStockItemViewModel));
		}

	}
}

