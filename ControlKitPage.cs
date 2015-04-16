using System;

using Xamarin.Forms;

namespace GeStock
{
	public class ControlKitPage : ContentPage
	{
		public ControlKitPage ()
		{
			Title = "Kit de Commande";

			Padding = new Thickness (10, Device.OnPlatform (20, 5, 0), 10, 5);

			Content = new StackLayout { 
				Children = {
					new Label { Text = "Kit de Commande", HorizontalOptions = LayoutOptions.Center }
				}
			};
		}
	}
}


