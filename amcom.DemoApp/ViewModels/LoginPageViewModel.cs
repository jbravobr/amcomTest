using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Polly;
using Prism.Navigation;

namespace amcom.DemoApp.ViewModels
{
	public class LoginPageViewModel : BindableBase
	{
		public User user { get; set; } = new User();
		public DelegateCommand LogonCmd { get; set; }

		readonly IApplicationService<User> _userService;
		readonly IDialogsFunctions _dialogsService;
		readonly INavigationService _navigationService;
		readonly ISessionControl _sessionService;

		public LoginPageViewModel(IApplicationService<User> userService,
								  IDialogsFunctions dialogsService,
								  INavigationService navigationService,
								  ISessionControl sessionService)
		{
			_userService = userService;
			_dialogsService = dialogsService;
			_navigationService = navigationService;
			_sessionService = sessionService;

			LogonCmd = new DelegateCommand(Logon);
		}

		Action Logon
		{
			get
			{
				return new Action(async () =>
				{
					if (!user.IsUserDataValid)
					{
						_dialogsService.ShowToast(EnumToastType.Error, Constants.ErrorLoginInvalidUserData);
						return;
					}

					var policy = Policy
									.Handle<Exception>()
									.FallbackAsync(async (arg) => await Task.FromResult(false));

					var loginCorrect = await policy.ExecuteAsync(async () => await LoginCheck());

					if (!loginCorrect)
					{
						_dialogsService.HideLoading();
						_dialogsService.ShowToast(EnumToastType.Error, Constants.ErrorLoginInvalidUserData);
						return;
					}

					_sessionService.SaveSession();
					await _navigationService.NavigateAsync("RootPage/BaseNavigationPage/PrangCatalogPage");
				});
			}
		}

		async Task<bool> LoginCheck()
		{
			_dialogsService.ShowLoading("Validando dados");
			await Task.Delay(5000);

			Expression<Func<User, bool>> predicate = (p) => p.Login == user.Login && p.Password == user.Password;
			var ret = await _userService.GetByPredicate(predicate);

			return ret.Id > 0;
		}
	}
}