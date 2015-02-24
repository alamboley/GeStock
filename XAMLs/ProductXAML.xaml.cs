using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;

namespace GeStock {

	public partial class ProductXAML : ContentPage {

		GeStockItem _geStockItem;
		ToolbarItem edit;

		bool _canEdit = false;

		public ProductXAML (GeStockItem geStockItem)
		{
			_geStockItem = geStockItem;

			BindingContext = _geStockItem;

			InitializeComponent ();

			edit = new ToolbarItem {
				Text = "Editer",
				Command = new Command(ShowEditPage)
			};

			ToolbarItems.Add (edit);
		}

		void ShowEditPage() {

			_canEdit = !_canEdit;

			this.FindByName<Stepper> ("quantity").IsVisible = _canEdit;

			edit.Text = _canEdit ? "Valider" : "Editer";
		}

	}
}

