using Xamarin.Forms;

namespace amcom.DemoApp.Views
{
	public partial class BlankPage : ContentPage
	{
		public BlankPage()
		{
			InitializeComponent();
		}

		protected override bool OnBackButtonPressed()
		{
			return false;
		}
	}
}