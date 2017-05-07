using System;
namespace amcom.DemoApp
{
	public class Session
	{
		public Guid Id { get; set; }
		public User LoggedUser { get; set; }
		public DateTime CreationDate { get; private set; } = DateTime.Now;

		public bool ValidateDate
		{
			get
			{
				return DateTime.Now <= CreationDate.Add(TimeSpan.FromHours(23));
			}
		}
	}
}