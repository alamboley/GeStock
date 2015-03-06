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

			Content = new StackLayout { 
				Children = {
					product,
					category
				}
			};

			product.Clicked += OnButtonClicked;
			category.Clicked += OnButtonClicked;
		}

		void OnButtonClicked(object sender, EventArgs e) {

			switch (((Button)sender).Text) {

				case "Produit":
					Navigation.PushAsync (new NewProductXAML ());
					break;

				case "Catégorie":
					Navigation.PushAsync (new NewCategoryXAML ());
					break;
			}

		}
	}
}


