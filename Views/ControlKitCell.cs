using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace GeStock {
	
	public class ControlKitCell:ViewCell {

		static public bool showDelete = true;
		static public string IdMessage;

		static public bool _useRedBG = false;
		
		public ControlKitCell () {

			Label name = new Label ();
			name.SetBinding (Label.TextProperty, "Name");

			if (_useRedBG)
				name.BackgroundColor = Color.Red;

			name.VerticalOptions = LayoutOptions.Center;

			Button useKit = new Button ();

			if (!_useRedBG) {
				useKit.Text = "Sortir produits";
				useKit.HorizontalOptions = LayoutOptions.EndAndExpand;
			}
			
			useKit.Clicked += (sender, e) => {

				Debug.WriteLine("clicked");
			};

			StackLayout layout = new StackLayout {

				Padding = new Thickness(20, 0, 20, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {name, useKit}
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

