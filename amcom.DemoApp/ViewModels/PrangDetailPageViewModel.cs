using Prism.Mvvm;
using Prism.Navigation;
using PropertyChanged;
using System.Threading.Tasks;

namespace amcom.DemoApp.ViewModels
{
	[ImplementPropertyChanged]
	public class PrangDetailPageViewModel : BindableBase, INavigationAware
	{
		readonly IDialogsFunctions _dialogService;

		public Car Car { get; set; }
		public string Title { get; set; }

		public PrangDetailPageViewModel(IDialogsFunctions dialogService)
		{
			_dialogService = dialogService;
		}

		public void OnNavigatedFrom(NavigationParameters parameters)
		{
		}

		public void OnNavigatedTo(NavigationParameters parameters)
		{
		}

		public async void OnNavigatingTo(NavigationParameters parameters)
		{
			if (parameters.ContainsKey("Car") && Car == null)
			{
				_dialogService.ShowLoading("Carregando informações");

				await Task.Delay(5000);
				Car = parameters["Car"] as Car;
				Title = Car.Name;

				_dialogService.HideLoading();
			}
		}
	}
}