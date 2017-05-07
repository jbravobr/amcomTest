using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Polly;
using PropertyChanged;
using System.Threading.Tasks;

namespace amcom.DemoApp.ViewModels
{
	[ImplementPropertyChanged]
	public class PhotosPageViewModel : BindableBase
	{
		readonly IApplicationService<Car> _carService;
		readonly IDialogsFunctions _dialogService;

		List<Car> Cars { get; set; }
		public List<Photo> Photos { get; set; } = new List<Photo>();

		public PhotosPageViewModel(IApplicationService<Car> carService,
								   IDialogsFunctions dialogService)
		{
			_carService = carService;
			_dialogService = dialogService;

			GetAllCars();
			FillPhotos();
		}

		void GetAllCars()
		{
			var policy = Policy
				.Handle<Exception>()
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
				.FallbackAsync(async (task) => _dialogService.ShowToast(EnumToastType.Error, "Erro ao exibir galeria de fotos"));
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously

			_dialogService.ShowLoading("Carregando fotos");

			Cars = policy.ExecuteAsync(async () => await _carService.GetAll()).Result;
			Task.Delay(3000);

			_dialogService.HideLoading();
		}

		void FillPhotos()
		{
			if (Cars == null || !Cars.Any())
			{
				_dialogService.ShowToast(EnumToastType.Error, "Erro com a lista de Fotos");
				return;
			}

			Cars.ForEach((car) => Photos.AddRange(car.Photos));
		}
	}
}