using System;

using SQLite.Net;

namespace MovieApi
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection();
	}
}

