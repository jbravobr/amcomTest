using System;
using Xamarin.Forms;

namespace amcom.DemoApp.Views
{
	public partial class GalleryImageTemplate : ContentView
	{
		public GalleryImageTemplate()
		{
			InitializeComponent();
		}

		public static BindableProperty ImageProperty =
			BindableProperty.Create(
				nameof(Image),
				typeof(ImageSource),
				typeof(GalleryImageTemplate),
				null,
				defaultBindingMode: BindingMode.OneWay
			);

		public ImageSource Image
		{
			get { return (ImageSource)GetValue(ImageProperty); }
			set { SetValue(ImageProperty, value); }
		}

		public static BindableProperty AddressNameProperty =
			BindableProperty.Create(
				"AddressName",
				typeof(string),
				typeof(GalleryImageTemplate),
				default(string));

		public string AddressName
		{
			get { return (string)GetValue(AddressNameProperty); }
			set { SetValue(AddressNameProperty, value); }
		}

		public async void OnImageTapped(object sender, EventArgs e)
		{
			var selectedItem = (GalleryImageTemplate)sender;
			var galleryImagePreview = new GalleryImagePreviewPage(selectedItem.Image, selectedItem.AddressName);

			await Navigation.PushModalAsync(new NavigationPage(galleryImagePreview) { BarTextColor = Color.White });
		}
	}
}