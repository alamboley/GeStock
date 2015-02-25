using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;

namespace GeStock {

	public partial class ProductXAML : ContentPage {

		GeStockItem _geStockItem;

		bool _canEdit = false;

		public ProductXAML (GeStockItem geStockItem)
		{
			_geStockItem = geStockItem;

			BindingContext = _geStockItem;

			InitializeComponent ();
		}

		void ShowEditPage(object sender, EventArgs e) {

			_canEdit = !_canEdit;

			this.FindByName<Stepper> ("quantity").IsVisible = _canEdit;

			((ToolbarItem)sender).Text = _canEdit ? "Valider" : "Modifier";
		}

	}
}

