using System;
using SQLite.Net.Attributes;

namespace GeStock {
	
	public class ControlKit:IDBObject {
		public ControlKit ()
		{
		}

		public ControlKit (ControlKit controlKit) {

			ID = controlKit.ID;
			Name = controlKit.Name;
			Elements = controlKit.Elements;
		}

		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Name { get; set; }
		public string Elements { get; set; }
	}
}

