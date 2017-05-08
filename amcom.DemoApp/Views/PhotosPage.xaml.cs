using Xamarin.Forms;

namespace amcom.DemoApp.Views
{
	public partial class PhotosPage : ContentPage
	{
		public PhotosPage()
		{
			InitializeComponent();
		}

		protected override bool OnBackButtonPressed()
		{
			return true;
		}
	}
}