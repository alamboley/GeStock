using System;

using Xamarin.Forms;

namespace GeStock
{
	public class MainMenuTabbedPage : TabbedPage
	{
		public MainMenuTabbedPage ()
		{
			Title = "TabbedPage";

			Children.Add(new NavigationPageStock(new StockPage()));

			Children.Add(new NavigationPage(new SearchPage()) {
				Title = "Rechercher"
			});

			Children.Add(new InventoryPage());
		}
	}
}


