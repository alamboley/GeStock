using System;
using System.ComponentModel;
using System.Diagnostics;

namespace GeStock {

	public class GeStockItemViewModel:INotifyPropertyChanged {

		public event PropertyChangedEventHandler PropertyChanged;

		public GeStockItem StockItem { get; private set; }

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

		string category;
		public string Category {

			set {
				if (category != value) {
					category = value;

					OnPropertyChanged ("Category");
				}
			}

			get { return category; }
		}

		public int CategoryIndex { get ; set;}

		public GeStockItemViewModel (GeStockItem stockItem) {

			StockItem = stockItem;

			quantity = StockItem.Quantity;
			name = StockItem.Name;

			if (StockItem.ID != 0)
				category = App.Database.GetCategory(StockItem.Category).Name;

			CategoryIndex = StockItem.Category;
		}

		public void Restore(GeStockItem originalStockItem) {

			Name = StockItem.Name = originalStockItem.Name;
			Quantity = StockItem.Quantity = originalStockItem.Quantity;
		}

		public void Save() {

			StockItem.Name = name;
			StockItem.Quantity = quantity;
			StockItem.Category = CategoryIndex;

			App.Database.SaveItem (StockItem);
		}

		protected void OnPropertyChanged(string propertyName) {

			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

