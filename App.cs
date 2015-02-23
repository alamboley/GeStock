using System;
using Xamarin.Forms;
using System.Diagnostics;

namespace GeStock
{
	public class App : Application
	{

		static GeStockItemDatabase database;

		public App ()
		{
			// The root page of your application

			MainPage = new MyTabbedPage();
		}

		public static GeStockItemDatabase Database {

			get {
				if (database == null)
					database = new GeStockItemDatabase ();

				return database;
			}
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}

