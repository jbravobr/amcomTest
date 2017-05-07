using FFImageLoading.Forms.Touch;
using Foundation;
using Lottie.Forms.iOS.Renderers;
using UIKit;

namespace amcom.DemoApp.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();
			CachedImageRenderer.Init();
			AnimationViewRenderer.Init();

			UXDivers.Artina.Shared.GrialKit.Init(new ThemeColors(), "amcom.DemoApp.iOS.GrialLicense");


			// Code for starting up the Xamarin Test Cloud Agent
#if ENABLE_TEST_CLOUD
			Xamarin.Calabash.Start();
#endif

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}