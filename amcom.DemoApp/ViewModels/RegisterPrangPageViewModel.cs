using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Polly;
using Plugin.Media.Abstractions;
using PropertyChanged;
using Prism.Navigation;
using Plugin.Geolocator.Abstractions;
using System.Collections;

namespace amcom.DemoApp.ViewModels
{
	[ImplementPropertyChanged]
	public class RegisterPrangPageViewModel : BindableBase
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public List<Photo> Photos { get; set; }
		public bool IsPhotoTake { get; set; } = false;
		public DelegateCommand SaveCommand { get; set; }
		public DelegateCommand TakePhotoCommand { get; set; }
		public int CountPhotos { get; set; } = 0;

		readonly IApplicationService<Car> _carService;
		readonly IDialogsFunctions _dialogService;
		readonly IMedia _mediaService;
		readonly IGeolocator _geoService;
		readonly INavigationService _navigationService;

		public RegisterPrangPageViewModel(IApplicationService<Car> carService,
										  IDialogsFunctions dialogService,
										  IMedia mediaService,
										  INavigationService navigationService,
										  IGeolocator geoService)
		{
			_carService = carService;
			_dialogService = dialogService;
			_mediaService = mediaService;
			_navigationService = navigationService;
			_geoService = geoService;

			SaveCommand = new DelegateCommand(Save);
			TakePhotoCommand = new DelegateCommand(TakePhoto);
		}

		Action Save
		{
			get
			{
				return new Action(async () =>
				{
					var car = new Car
					{
						Name = this.Name,
						Description = this.Description,
						Photos = this.Photos
					};

					var policy = Policy
						.Handle<Exception>()
						.FallbackAsync(async (task) => _dialogService.ShowToast(EnumToastType.Error, "Erro ao salvar registro"));

					await _carService.Insert(car);

					var carRet = await _carService.GetAll();
					if (carRet.OrderByDescending(x => x.Id).FirstOrDefault().Name == this.Name)
					{
						_dialogService.ShowToast(EnumToastType.Success, "Dados salvos com sucesso");
						await _navigationService.GoBackAsync();
					}
					else
					{
						_dialogService.ShowToast(EnumToastType.Error, "Erro ao salvar dados, tente novamente");
						return;
					}
				});
			}
		}

		Action TakePhoto
		{
			get
			{
				return new Action(async () =>
				{
					await _mediaService.Initialize();

					if (!_mediaService.IsCameraAvailable || !_mediaService.IsTakePhotoSupported)
					{
						_dialogService.ShowToast(EnumToastType.Warning, "Nenhuma câmera encontrada");
						return;
					}

					var policy = Policy
						.Handle<Exception>()
						.FallbackAsync(async (task) => _dialogService.ShowToast(EnumToastType.Error, "Erro ao capturar foto, por favor tente novamente"));

					var fileName = $"{System.IO.Path.GetRandomFileName()}.jpg";
					var file = await policy.ExecuteAsync(async () => await _mediaService.TakePhotoAsync(new StoreCameraMediaOptions
					{
						PhotoSize = PhotoSize.Medium,
						Directory = "Sample",
						Name = fileName
					}));

					if (file == null)
					{
						_dialogService.ShowToast(EnumToastType.Error, "Erro ao capturar foto, por favor tente novamente");
						return;
					}

					var geoPolicy = Policy
						.Handle<Exception>()
						.FallbackAsync(async (task) => _dialogService.ShowToast(EnumToastType.Warning, "Erro ao detectar posição geográfica"));

					IEnumerable<Plugin.Geolocator.Abstractions.Address> addresses = null;
					_geoService.DesiredAccuracy = 50;
					var position = await geoPolicy.ExecuteAsync(async () => await _geoService.GetPositionAsync(TimeSpan.FromSeconds(10)));
					if (position == null)
						_dialogService.ShowToast(EnumToastType.Warning, "Erro ao detectar posição geográfica");
					else
						addresses = await geoPolicy.ExecuteAsync(async () => await _geoService.GetAddressesForPositionAsync(position));

					if (Photos == null)
						Photos = new List<Photo>();

					Photos.Add(new Photo
					{
						Name = fileName,
						PhotoStream = fileName,
						PickDate = DateTimeOffset.Now,
						Size = file.GetStream().Length,
						Geocoordinate = new Geocoordinate
						{
							Latitude = position.Latitude,
							Longitude = position.Longitude,
							Address = addresses != null && addresses.Any() ?
																	$"{addresses.FirstOrDefault().Thoroughfare},{addresses.FirstOrDefault().Locality},{addresses.FirstOrDefault().CountryName}" :
																	string.Empty
						}
					});

					CountPhotos++;
					IsPhotoTake = true;
					fileName = string.Empty;
				});
			}
		}
	}
}