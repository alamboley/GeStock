using System;
using SQLite.Net.Attributes;

namespace GeStock
{
	public class GeStockItem : IDBObject
	{
		public GeStockItem ()
		{
		}

		public GeStockItem (GeStockItem stockItem) {

			ID = stockItem.ID;
			Name = stockItem.Name;
			Quantity = stockItem.Quantity;
			Description = stockItem.Description;
			Location = stockItem.Location;
			Category = stockItem.Category;
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; }
		public string Description { get; set; }
		public string Location { get; set; }
		public int Category { get; set; }
	}
}

