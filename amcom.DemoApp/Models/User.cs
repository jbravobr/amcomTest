using SQLite;

namespace amcom.DemoApp
{
	public class User : EntityBase
	{
		public string Name { get; set; }
		public string Password { get; set; }
		public string Login { get; set; }

		[Ignore]
		public bool IsUserDataValid
		{
			get
			{
				return !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password);
			}
		}
	}
}