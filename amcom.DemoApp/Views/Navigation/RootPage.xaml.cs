using System;
using Prism.Navigation;
using Xamarin.Forms;

namespace amcom.DemoApp.Views
{
	public partial class RootPage : MasterDetailPage, IMasterDetailPageOptions
	{
		public RootPage()
		{
			InitializeComponent();
		}

		public bool IsPresentedAfterNavigation => Device.Idiom != TargetIdiom.Phone;
	}
}