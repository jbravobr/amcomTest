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

		[ForeignKey(typeof(Geocoordinate))]
		public int GeocoordinateId { get; set; }

		[OneToOne]
		public Geocoordinate Geocoordinate { get; set; }

		public string Address { get; set; }

		[ForeignKey(typeof(Car))]
		public int CarId { get; set; }
	}
}