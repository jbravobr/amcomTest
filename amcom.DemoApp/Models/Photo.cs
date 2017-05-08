using System;
using SQLiteNetExtensions.Attributes;

namespace amcom.DemoApp
{
	public class Photo : EntityBase
	{
		public string Name { get; set; }
		public DateTimeOffset PickDate { get; set; }
		public long Size { get; set; }
		public string PhotoStream { get; set; }
		public string Address { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }

		[ForeignKey(typeof(Car))]
		public int CarId { get; set; }
	}
}