using System;
using System.ComponentModel;
using System.Diagnostics;

namespace GeStock {

	public class GeStockItemViewModel:INotifyPropertyChanged {

		public event PropertyChangedEventHandler PropertyChanged;

		GeStockItem StockItem;

		string name;
		public string Name {

			set {
				if (name != value) {
					name = value;

					OnPropertyChanged ("Name");
				}
			}

			get { return name; }
		}

		int quantity;
		public int Quantity {

			set {
				if (quantity != value) {
					quantity = value;

					OnPropertyChanged ("Quantity");
				}
			}

			get { return quantity; }
		}

		int category;
		public int Category {

			set {
				if (category != value) {
					category = value;

					OnPropertyChanged ("Category");
				}
			}

			get { return category; }
		}

		public GeStockItemViewModel (GeStockItem stockItem) {

			StockItem = stockItem;

			quantity = StockItem.Quantity;
			name = StockItem.Name;
			category = StockItem.Category;
		}

		public void Save() {

			StockItem.Name = name;
			StockItem.Quantity = quantity;
			StockItem.Category = category;

			App.Database.SaveItem (StockItem);
		}

		protected void OnPropertyChanged(string propertyName) {

			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

