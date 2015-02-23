using System;

using Xamarin.Forms;

namespace GeStock
{
	public class MyTabbedPage : TabbedPage
	{
		public MyTabbedPage ()
		{
			Title = "TabbedPage";

			Children.Add(new StockPage());

			Children.Add(new SearchPage());

			Children.Add(new InventoryPage());
		}
	}
}


