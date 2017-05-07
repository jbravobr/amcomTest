using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;
using FFImageLoading.Forms.Droid;
using Lottie.Forms.Droid;
using Plugin.Permissions;

namespace amcom.DemoApp.Droid
{
	[Activity(Label = "Sliphis",
			  Icon = "@drawable/ic_launcher",
			  Theme = "@style/MyTheme",
			  ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
			  ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
			UXDivers.Artina.Shared.GrialKit.Init(this, "amcom.DemoApp.Droid.GrialLicense");

			Acr.UserDialogs.UserDialogs.Init(() => (Activity)Forms.Context);
			CachedImageRenderer.Init();
			AnimationViewRenderer.Init();

			LoadApplication(new App());
		}

		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, Permission[] grantResults)
		{
			PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}
	}
}