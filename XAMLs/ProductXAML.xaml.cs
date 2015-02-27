using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;

namespace GeStock {

	public partial class ProductXAML : ContentPage {

		GeStockItemViewModel _geStockItemViewModel;

		bool _canEdit = false;

		public ProductXAML (GeStockItem geStockItem)
		{
			_geStockItemViewModel = new GeStockItemViewModel( geStockItem);;

			BindingContext = _geStockItemViewModel;

			InitializeComponent ();
		}

		void ShowEditPage(object sender, EventArgs e) {

			_canEdit = !_canEdit;

			this.FindByName<Stepper> ("quantity").IsVisible = _canEdit;

			if (!_canEdit)
				_geStockItemViewModel.Save ();

			((ToolbarItem)sender).Text = _canEdit ? "Valider" : "Modifier";
		}

	}
}

