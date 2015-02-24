using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;

namespace GeStock {

	public partial class ProductXAML : ContentPage {

		GeStockItem _geStockItem;

		public ProductXAML (GeStockItem geStockItem)
		{
			_geStockItem = geStockItem;

			BindingContext = _geStockItem;

			InitializeComponent ();
		}

	}
}

