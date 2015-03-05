using System;

using Xamarin.Forms;
using System.Diagnostics;

namespace GeStock {

	public class AddPage : ContentPage {

		public AddPage () {

			Title = "Ajouter";

			Button product = new Button {
				Text = "Produit",
			};

			Content = new StackLayout { 
				Children = {
					product
				}
			};

			product.Clicked += OnButtonClicked;
		}

		void OnButtonClicked(object sender, EventArgs e) {

			Navigation.PushAsync(new NewProductXAML());
		}
	}
}


