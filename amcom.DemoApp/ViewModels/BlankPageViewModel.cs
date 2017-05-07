using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;
using Polly;
using Prism.Navigation;
using System;

namespace amcom.DemoApp.ViewModels
{
	public class BlankPageViewModel : BindableBase
	{
		readonly IApplicationService<User> _userService;
		readonly INavigationService _navigationService;
		readonly IDialogsFunctions _dialogService;
		readonly ISessionControl _sessionService;

		User user;

		public BlankPageViewModel(IApplicationService<User> userService,
								  INavigationService navigationService,
								  IDialogsFunctions dialogService,
								  ISessionControl sessionService)
		{
			_userService = userService;
			_dialogService = dialogService;
			_navigationService = navigationService;
			_sessionService = sessionService;

			var session = _sessionService.GetSavedSession();

			if (session != null && session.ValidateDate)
				NavigateToFirstPage();
			else if (session != null && !session.ValidateDate)
			{
				_sessionService.DeleteSession();
				CreateUserIfNotExist();
			}
			else
				CreateUserIfNotExist();
		}

		void CreateUserIfNotExist()
		{
			try
			{
				var policy = Policy
					.Handle<Exception>()
					.FallbackAsync(async (arg) => _dialogService.ShowAlert(Constants.ErrorCreateUserForLogin));

				var users = policy.ExecuteAsync(async () => await _userService.GetAll()).Result;

				if (users != null && users.Any())
					NavigateToLogin();
				else
				{
					user = UserHelper.CreateFakeUser();
					policy.ExecuteAsync(async () => await _userService.Insert(user));
					NavigateToLogin();
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		void NavigateToLogin() => _navigationService.NavigateAsync("LoginPage");
		void NavigateToFirstPage() => _navigationService.NavigateAsync("RootPage/BaseNavigationPage/PrangCatalogPage");
	}
}