using System;

using Xamarin.Forms;
using System.Diagnostics;

namespace GeStock {

	public class AddPage : ContentPage {

		public AddPage () {

			Title = "Ajouter";

			Button product = new Button {
				Text = "Produit"
			};

			Button category = new Button {
				Text = "Catégorie"
			};

			Button controlKit = new Button {
				Text = "Kit"
			};

			Content = new StackLayout { 
				Children = {
					product,
					category,
					controlKit
				}
			};

			product.Clicked += OnButtonClicked;
			category.Clicked += OnButtonClicked;
			controlKit.Clicked += OnButtonClicked;
		}

		void OnButtonClicked(object sender, EventArgs e) {

			switch (((Button)sender).Text) {

				case "Produit":
					Navigation.PushAsync (new NewProductXAML ());
					break;

				case "Catégorie":
					Navigation.PushAsync (new NewCategoryXAML ());
					break;

				case "Kit":
					Navigation.PushAsync (new NewControlKitXAML ());
					break;
			}

		}
	}
}


