using SQLite;

namespace amcom.DemoApp
{
	public class EntityBase
	{
		[PrimaryKey,AutoIncrement]
		public int Id { get; set; }
	}
}