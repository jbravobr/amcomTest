using SQLite;

namespace amcom.DemoApp
{
	public interface ISQLite
	{
		SQLiteConnection GetConn();
	}
}