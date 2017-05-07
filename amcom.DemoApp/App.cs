using Prism.Unity;
using Microsoft.Practices.Unity;
using SQLite;
using amcom.DemoApp.Views;
using Xamarin.Forms.Xaml;

namespace amcom.DemoApp
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public class App : PrismApplication
	{
		public static SQLiteConnection AppSQLiteConn { get; set; }

		protected override void OnInitialized()
		{
			NavigationService.NavigateAsync("BlankPage");
		}

		protected override void RegisterTypes()
		{
			Container.RegisterType(typeof(IApplicationService<>), typeof(ApplicationService<>));
			Container.RegisterType(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
			Container.RegisterType(typeof(IDialogsFunctions), typeof(DialogsFunctions));
			Container.RegisterType(typeof(ISessionControl), typeof(SessionControl));

			Container.RegisterInstance(Acr.UserDialogs.UserDialogs.Instance);
			Container.RegisterInstance(Acr.Settings.Settings.Current);
			Container.RegisterInstance(Plugin.Media.CrossMedia.Current);
			Container.RegisterInstance(Plugin.Geolocator.CrossGeolocator.Current);

			Container.RegisterTypeForNavigation<LoginPage>();
			Container.RegisterTypeForNavigation<RootPage>();
			Container.RegisterTypeForNavigation<BlankPage>();
			Container.RegisterTypeForNavigation<BaseNavigationPage>();
			Container.RegisterTypeForNavigation<PrangDetailPage>();
			Container.RegisterTypeForNavigation<PrangCatalogPage>();
			Container.RegisterTypeForNavigation<PhotosPage>();
			Container.RegisterTypeForNavigation<RegisterPrangPage>();
		}
	}
}