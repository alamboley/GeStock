using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace GeStock {

	public class GeStockItemCell : ViewCell {

		static public bool showDelete = true;
		static public string IdMessage;

		static public bool _useRedBG = false;

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

			if (_useRedBG)
				View.BackgroundColor = Color.Red;

			if (showDelete) {

				var deleteAction = new MenuItem { Text = "Delete", IsDestructive = true };
				deleteAction.SetBinding (MenuItem.CommandParameterProperty, new Binding ("."));
				deleteAction.Clicked += (sender, e) => {

					var mi = ((MenuItem)sender);

					MessagingCenter.Send<ListView, GeStockItem> ((ListView)Parent, IdMessage, (GeStockItem)mi.CommandParameter);
				};

				ContextActions.Add (deleteAction);
			}
		}
	}
}

