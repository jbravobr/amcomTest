using System;
namespace amcom.DemoApp
{
	public static class UserHelper
	{
		public static User CreateFakeUser()
		{
			return new User
			{
				Login = "user@amcom.com.br",
				Name = "amcom Demo User",
				Password = "123"
			};
		}
	}
}