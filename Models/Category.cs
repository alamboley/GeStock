using System;
using SQLite.Net.Attributes;

namespace GeStock {

	public class Category {

		public Category () 
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }
	}
}

