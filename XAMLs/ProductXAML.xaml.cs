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

			_refresh ();
		}

		void ShowEditPage(object sender, EventArgs e) {

			Navigation.PushAsync(new EditProductXAML(_geStockItemViewModel));
		}

		override protected void OnAppearing() {
			base.OnAppearing();

			_refresh();
		}

		void _refresh() {

			CategoryDescription.Text = App.Database.GetCategory (_geStockItemViewModel.CategoryIndex).Description;
		}

	}
}

