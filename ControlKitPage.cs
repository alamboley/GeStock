﻿using System;

using Xamarin.Forms;
using System.Collections.ObjectModel;

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

				Navigation.PushAsync(new ControlKitXAML (controlKit));
			};

			MessagingCenter.Subscribe<ListView, ControlKit> (listView, "deleteItemCell", (sender, arg) => {
				_myItems.Remove(arg);

				App.Database.Delete((ControlKit) arg);
			});
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


