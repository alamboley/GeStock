using System;
using SQLite.Net.Attributes;
using System.ComponentModel;

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
		public int Category { get; set; }
	}
}

