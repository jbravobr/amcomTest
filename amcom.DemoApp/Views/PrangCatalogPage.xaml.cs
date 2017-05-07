using Xamarin.Forms;

namespace amcom.DemoApp.Views
{
	public partial class PrangCatalogPage : ContentPage
	{
		public PrangCatalogPage()
		{
			InitializeComponent();

			carsListView.ItemSelected += (sender, e) =>
			{
				((ListView)sender).SelectedItem = null;
			};
		}
	}
}