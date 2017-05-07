using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Util;

namespace amcom.DemoApp.Droid
{
	[Activity(Label = "Sliphis", Theme = "@style/MyTheme.Splash", MainLauncher = true)]
	public class SplashActivity : AppCompatActivity
	{
		static readonly string TAG = "X:" + typeof(SplashActivity).Name;

		public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
		{
			base.OnCreate(savedInstanceState, persistentState);
			Log.Debug(TAG, "SplashActivity.OnCreate");
		}

		protected override void OnResume()
		{
			base.OnResume();
			Task startupWork = new Task(SimulateStartup);
			startupWork.Start();
		}

		async void SimulateStartup()
		{
			await Task.Delay(4000);
			StartActivity(new Intent(Application.Context, typeof(MainActivity)));
		}

		public override void OnBackPressed() { }
	}
}