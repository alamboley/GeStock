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

			Button useKit = null;

			if (!_useRedBG) {
				useKit = new Button ();
				useKit.Text = "Sortir produits";
				useKit.HorizontalOptions = LayoutOptions.EndAndExpand;

				useKit.Clicked += async (sender, e) => {

					var answer = await ((ControlKitPage)Parent.Parent.Parent).DisplayAlert ("Attention", "Êtes vous sûr de vouloir sortir ce kit ?", "Oui", "Non");

					if (answer)
						MessagingCenter.Send<ListView, string> ((ListView)Parent, "useKit", name.Text);
				};
			}

			StackLayout layout = new StackLayout {

				Padding = new Thickness(20, 0, 20, 0),
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Children = {name}
			};

			if (useKit != null)
				layout.Children.Add (useKit);

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

