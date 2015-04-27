using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;

namespace GeStock {
	
	public partial class ControlKitXAML : ContentPage {

		ControlKitViewModel _controlKitViewModel;

		public ControlKitXAML (ControlKit controlKit)
		{
			_controlKitViewModel = new ControlKitViewModel (controlKit);

			BindingContext = _controlKitViewModel;

			InitializeComponent ();

			dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject (_controlKitViewModel.Elements);

			foreach (var property in json) {

				Debug.WriteLine(property.Name + ":" + property.Value);
			}
		}

		void ShowEditPage(object sender, EventArgs e) {

			//Navigation.PushAsync(new EditProductXAML(_geStockItemViewModel));
		}
	}
}

