using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace GeStock {

	public partial class NewCategoryXAML : ContentPage {

		CategoryViewModel categoryMV;

		public NewCategoryXAML () {
			InitializeComponent ();

			NewProduct ();
		}

		void NewProduct() {

			categoryMV = new CategoryViewModel(new Category());

			BindingContext = categoryMV;
		}

		void SaveAndNewCategory(object sender, EventArgs e) {

			if (!String.IsNullOrEmpty(categoryMV.Name)) {

				categoryMV.Save ();

				NewProduct ();

			} else 
				DisplayAlert ("Attention", "Vous devez entrer un nom pour la catégorie !", "Ok");
		}
	}
}

