using System;

using Xamarin.Forms;
using System.Diagnostics;

namespace GeStock {

	public class NavigationPageStock : NavigationPage {

		public NavigationPageStock (Page root):base(root)
		{
			Title = "Stock";

			this.Popped += (object sender, NavigationEventArgs e) => {
			};
		}
	}
}


