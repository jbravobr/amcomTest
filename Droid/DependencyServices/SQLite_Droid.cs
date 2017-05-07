using System;
using System.IO;
using amcom.DemoApp.Droid;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Droid))]
namespace amcom.DemoApp.Droid
{
	public class SQLite_Droid : ISQLite
	{
		public SQLiteConnection GetConn()
		{
			var sqliteFilename = "amcomDatabase.db3";
			string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			var path = Path.Combine(documentsPath, sqliteFilename);
			var conn = new SQLiteConnection(path);

			return conn;
		}
	}
}