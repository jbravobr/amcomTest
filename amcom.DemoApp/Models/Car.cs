using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace amcom.DemoApp
{
	public class Car : EntityBase
	{
		public string Image { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }

		[OneToMany(CascadeOperations = CascadeOperation.All)]
		public List<Photo> Photos { get; set; }
	}
}