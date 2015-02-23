using System;
using SQLite.Net;

namespace GeStock
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}

