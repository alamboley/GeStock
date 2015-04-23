using System;
using Xamarin.Forms;

namespace GeStock {
	
	public class ControlKitCell:ViewCell {
		
		public ControlKitCell () {

			Label name = new Label ();
			name.SetBinding (Label.TextProperty, "Name");

			name.VerticalOptions = LayoutOptions.Center;

			StackLayout layout = new StackLayout {

				Padding = new Thickness(20, 0, 20, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {name}
			};

			View = layout;
		}
	}
}

