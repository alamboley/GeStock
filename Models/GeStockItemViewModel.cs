using System;
using System.ComponentModel;
using System.Diagnostics;

namespace GeStock {

	public class GeStockItemViewModel:AViewModel {

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

		string description;
		public string Description {

			set {
				if (description != value) {
					description = value;

					OnPropertyChanged ("Description");
				}
			}

			get { return description; }
		}

		string location;
		public string Location {

			set {
				if (location != value) {
					location = value;

					OnPropertyChanged ("Location");
				}
			}

			get { return location; }
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
			description = StockItem.Description;
			location = StockItem.Location;

			if (StockItem.ID != 0)
				category = App.Database.GetCategory(StockItem.Category).Name;

			CategoryIndex = StockItem.Category;
		}

		public void Restore(GeStockItem originalStockItem) {

			Name = StockItem.Name = originalStockItem.Name;
			Quantity = StockItem.Quantity = originalStockItem.Quantity;
			Description = StockItem.Description = originalStockItem.Description;
			Location = StockItem.Location = originalStockItem.Location;
		}

		public void Save() {

			StockItem.Name = name;
			StockItem.Quantity = quantity;
			StockItem.Description = description;
			StockItem.Location = location;
			StockItem.Category = CategoryIndex;

			App.Database.Save (StockItem);
		}
	}
}

