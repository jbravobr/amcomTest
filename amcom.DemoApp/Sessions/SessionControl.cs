using System;
using System.Collections.Generic;
using System.Linq;
using Acr.Settings;

namespace amcom.DemoApp
{
	public class SessionControl : ISessionControl
	{
		readonly ISettings _settingsService;
		readonly IApplicationService<User> _userService;

		public SessionControl(ISettings settingsService,
							  IApplicationService<User> userService)
		{
			_settingsService = settingsService;
			_userService = userService;
		}

		public void DeleteSession()
		{
			if (_settingsService.Contains("Session"))
				_settingsService.Remove("Session");
		}

		public Session GetSavedSession()
		{
			return _settingsService.Get<Session>("Session");
		}

		public bool IsValid()
		{
			var session = GetSavedSession();
			if (session != null)
				return session.ValidateDate;

			return false;
		}

		public void SaveSession()
		{
			var user = new NotifyTaskCompletion<List<User>>(_userService.GetAll()).Result.FirstOrDefault();
			_settingsService.Set("Session", new Session { Id = Guid.NewGuid(), LoggedUser = user });
		}
	}
}