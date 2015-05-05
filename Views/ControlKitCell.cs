using System;
using Xamarin.Forms;

namespace GeStock {
	
	public class ControlKitCell:ViewCell {

		static public bool showDelete = true;
		static public string IdMessage;
		
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

			if (showDelete) {

				var deleteAction = new MenuItem { Text = "Delete", IsDestructive = true };
				deleteAction.SetBinding (MenuItem.CommandParameterProperty, new Binding ("."));
				deleteAction.Clicked += (sender, e) => {

					var mi = ((MenuItem)sender);

					MessagingCenter.Send<ListView, ControlKit> ((ListView)Parent, IdMessage, (ControlKit)mi.CommandParameter);
				};

				ContextActions.Add (deleteAction);
			}
		}
	}
}

