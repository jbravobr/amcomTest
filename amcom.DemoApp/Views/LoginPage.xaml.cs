using Xamarin.Forms;

namespace amcom.DemoApp.Views
{
	public partial class LoginPage : ContentPage
	{
		public LoginPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
		}

		protected override bool OnBackButtonPressed()
		{
			return false;
		}
	}
}