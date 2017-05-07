using Prism.Navigation;
using Xamarin.Forms;

namespace amcom.DemoApp.Views
{
	public partial class BaseNavigationPage : NavigationPage, INavigationPageOptions
	{
		public BaseNavigationPage(Page page) : base(page)
		{
			InitializeComponent();
		}

		public bool ClearNavigationStackOnNavigation
		{
			get
			{
				return false;
			}
		}
	}
}