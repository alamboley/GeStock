using System;
using Xamarin.Forms;

namespace GeStock {

	public class GeStockItemCell : ViewCell {

		public GeStockItemCell() {

			Label name = new Label ();
			name.SetBinding (Label.TextProperty, "Name");

			Label quantity = new Label ();
			quantity.SetBinding (Label.TextProperty, "Quantity");
			quantity.TextColor = Color.Gray;
			quantity.HorizontalOptions = LayoutOptions.EndAndExpand;

			name.VerticalOptions = quantity.VerticalOptions = LayoutOptions.Center;

			StackLayout layout = new StackLayout {
			
				Padding = new Thickness(20, 0, 20, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {name, quantity}
			};

			View = layout;
		}
	}
}

