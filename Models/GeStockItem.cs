using System;
using SQLite.Net.Attributes;

namespace GeStock
{
	public class GeStockItem
	{
		public GeStockItem ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }
		public int Quantity { get; set; }
	}
}

