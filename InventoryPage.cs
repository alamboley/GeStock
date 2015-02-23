using System;

using Xamarin.Forms;

namespace GeStock
{
	public class InventoryPage : ContentPage
	{
		public InventoryPage ()
		{
			Title = "Inventaire";

			Padding = new Thickness (10, Device.OnPlatform (20, 5, 0), 10, 5);

			Content = new StackLayout { 
				Children = {
					new Label { Text = "Inventaire", HorizontalOptions = LayoutOptions.Center }
				}
			};
		}
	}
}


