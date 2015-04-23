using System;
using SQLite.Net.Attributes;

namespace GeStock {
	
	public class ControlKit:IDBObject {
		public ControlKit ()
		{
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }
		public string Elements { get; set; }
	}
}

