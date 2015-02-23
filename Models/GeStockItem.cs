using System;
using SQLite.Net.Attributes;
using System.ComponentModel;

namespace GeStock
{
	public class GeStockItem : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		int quantity;
		public int Quantity {

			set {
				if (quantity != value) {
					quantity = value;

					if (PropertyChanged != null)
						PropertyChanged (this, new PropertyChangedEventArgs ("Quantity"));
				}
			}

			get {
				return quantity;
			}
		}

		public GeStockItem ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }
	}
}

