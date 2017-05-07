using Xamarin.Forms;

namespace amcom.DemoApp.Views
{
	public partial class MenuPage : ContentPage
	{
		public MenuPage()
		{
			InitializeComponent();

			menuListView.ItemSelected += (sender, e) =>
			{
				((ListView)sender).SelectedItem = null;
			};
		}

		protected override bool OnBackButtonPressed()
		{
			return true;
		}
	}
}

