using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;
using System.Threading.Tasks;
using Polly;
using PropertyChanged;

namespace amcom.DemoApp.ViewModels
{
	[ImplementPropertyChanged]
	public class RootPageViewModel : BindableBase, INavigationAware
	{
		readonly IApplicationService<Menu> _appMenuService;
		readonly IApplicationService<Car> _appCarService;
		readonly INavigationService _navigationService;
		readonly IDialogsFunctions _dialogsService;
		readonly ISessionControl _sessionService;

		public List<Menu> Menus { get; set; }
		public List<Car> Cars { get; set; }

		public DelegateCommand<Menu> ItemTappedCommand { get; set; }
		public DelegateCommand<Car> CarItemTappedCommand { get; set; }

		public RootPageViewModel(IDialogsFunctions dialogsService,
								 IApplicationService<Menu> appMenuService,
								 IApplicationService<Car> appCarService,
								 INavigationService navigationService,
								 ISessionControl sessionService)
		{
			_dialogsService = dialogsService;
			_appMenuService = appMenuService;
			_appCarService = appCarService;
			_navigationService = navigationService;
			_sessionService = sessionService;

			ItemTappedCommand = new DelegateCommand<Menu>(ItemTapped);
			CarItemTappedCommand = new DelegateCommand<Car>(CarItemTapped);

			LoadingMenus();
			LoadingFakeCarsList();
		}

		async void LoadingMenus()
		{
			if (Menus == null || !Menus.Any())
			{
				_dialogsService.ShowLoading("Preparando Menu");

				await CreateMenusIfNotExist();
				await Task.Delay(5000);

				var menus = await GetMenus();
				if (menus != null && menus.Any())
					Menus = menus.OrderBy(x => x.Order).ToList();

				_dialogsService.HideLoading();
			}
		}

		async void LoadingFakeCarsList()
		{
			if (Cars == null || !Cars.Any())
			{
				_dialogsService.ShowLoading("Carregando lista de avarias");

				await CreateFakeCarsIfNotExist();
				await Task.Delay(5000);

				var cars = await GetCars();
				if (cars != null && cars.Any())
					Cars = cars.OrderByDescending(x => x.Id).ToList();

				_dialogsService.HideLoading();
			}
		}

		Action<Car> CarItemTapped
		{
			get
			{
				return new Action<Car>(async (car) =>
				{
					var parameters = new NavigationParameters();
					parameters.Add("Car", car);

					await NavigateTo(EnumMenuPages.PrangDetail.GetDescription(), parameters);
				});
			}
		}

		Action<Menu> ItemTapped
		{
			get
			{
				return new Action<Menu>((menu) =>
				{
					if (menu.MenuType == MenuType.Photo.GetDescription())
						CallPhotoGalleryMenu.Invoke();
					else if (menu.MenuType == MenuType.Quit.GetDescription())
						CallQuitMenu.Invoke();
					else if (menu.MenuType == MenuType.Register.GetDescription())
						CallRegisterMenu.Invoke();
				});
			}
		}

		Action CallPhotoGalleryMenu
		{
			get
			{
				return new Action(async () =>
				{
					var policy = Policy
						.Handle<Exception>()
						.FallbackAsync(async (task) => _dialogsService.ShowToast(EnumToastType.Error, Constants.PageNavigationError));

					await policy.ExecuteAsync(async () => await NavigateTo(EnumMenuPages.PhotoGallery.GetDescription()));
				});
			}
		}

		Action CallRegisterMenu
		{
			get
			{
				return new Action(async () =>
				{
					var policy = Policy
						.Handle<Exception>()
						.FallbackAsync(async (task) => _dialogsService.ShowToast(EnumToastType.Error, Constants.PageNavigationError));

					await policy.ExecuteAsync(async () => await NavigateTo(EnumMenuPages.Register.GetDescription()));
				});
			}
		}

		Action CallQuitMenu
		{
			get
			{
				return new Action(async () =>
				{
					var policy = Policy
						.Handle<Exception>()
						.FallbackAsync(async (task) => _dialogsService.ShowToast(EnumToastType.Error, Constants.PageNavigationError));

					await policy.ExecuteAsync(async () => await NavigateTo(EnumMenuPages.Quit.GetDescription()));
				});
			}
		}

		async Task NavigateTo(string page)
		{
			if (page == EnumMenuPages.Quit.GetDescription())
			{
				_sessionService.DeleteSession();
				await _navigationService.NavigateAsync(new Uri("myapp:///LoginPage", UriKind.Absolute));
			}
			else
				await _navigationService.NavigateAsync($"BaseNavigationPage/{page}");
		}

		async Task NavigateTo(string page, NavigationParameters parameters)
		{
			if (page == EnumMenuPages.Quit.GetDescription())
			{
				_sessionService.DeleteSession();
				await _navigationService.NavigateAsync(new Uri("myapp:///LoginPage", UriKind.Absolute), parameters);
			}
			else
				await _navigationService.NavigateAsync($"BaseNavigationPage/{page}", parameters);
		}

		async Task CreateMenusIfNotExist()
		{
			var menus = await _appMenuService.GetAll();

			if (menus == null || !menus.Any())
				await ConfigureMenus();
		}

		async Task ConfigureMenus()
		{
			var menus = MenuHelper.BulkMenuList();
			menus.ForEach((menu) => _appMenuService.Insert(menu));
			menus = await _appMenuService.GetAll();
		}

		async Task CreateFakeCarsIfNotExist()
		{
			var cars = await _appCarService.GetAll();

			if (cars == null || !cars.Any())
				await ConfigureCars();
		}

		async Task ConfigureCars()
		{
			var cars = CarHelper.BulkCarList();
			cars.ForEach((car) => _appCarService.Insert(car));
			cars = await _appCarService.GetAll();
		}

		async Task<List<Menu>> GetMenus()
		{
			var policy = Policy
				.Handle<Exception>()
				.FallbackAsync(async (arg) => _dialogsService.ShowToast(EnumToastType.Error, Constants.ErrorLoadingMenus));

			var ret = await policy.ExecuteAsync(async () => await _appMenuService.GetAll());
			return ret;
		}

		async Task<List<Car>> GetCars()
		{
			var policy = Policy
				.Handle<Exception>()
				.FallbackAsync(async (arg) => _dialogsService.ShowToast(EnumToastType.Error, Constants.ErrorLoadingCars));

			var ret = await policy.ExecuteAsync(async () => await _appCarService.GetAll());
			return ret;
		}

		async Task ReloadingMainList()
		{
			var policy = Policy
				.Handle<Exception>()
				.FallbackAsync(async (task) => _dialogsService.ShowToast(EnumToastType.Error, "Erro ao recarregar lista de avarias"));

			var cars = await policy.ExecuteAsync(async () => await _appCarService.GetAll());
			if (cars != null && cars.Any())
				Cars = cars;
		}

		public async void OnNavigatedFrom(NavigationParameters parameters)
		{
			if (parameters.ContainsKey("Reload"))
				await ReloadingMainList();
		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
		}

		public void OnNavigatingTo(NavigationParameters parameters)
		{
		}
	}
}