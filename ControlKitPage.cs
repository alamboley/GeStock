using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace GeStock
{
	public class ControlKitPage : ContentPage
	{
		ObservableCollection<ControlKit> _myItems;

		public ControlKitPage ()
		{
			Title = "Kit de Commande";

			ListView listView = new ListView {
				RowHeight = 40,
				ItemTemplate = new DataTemplate(typeof(ControlKitCell))
			};

			_myItems = new ObservableCollection<ControlKit>();

			_refreshList();

			listView.ItemsSource = _myItems;

			Content = new StackLayout { 
				Children = {
					new Label { HorizontalOptions = LayoutOptions.Center },
					listView
				}
			};

			listView.ItemSelected += (sender, e) => {

				ControlKit controlKit = (ControlKit)e.SelectedItem;

				Debug.WriteLine("controlKit selected");

				//Navigation.PushAsync(new ProductXAML (controlKit));
			};
		}

		override protected void OnAppearing() {
			base.OnAppearing();

			_refreshList();
		}

		void _refreshList() {

			_myItems.Clear();

			var items = App.Database.GetControlKits();

			foreach (ControlKit controlKit in items)
				_myItems.Add(controlKit);
		}
	}
}


