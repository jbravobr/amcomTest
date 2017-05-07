using System.ComponentModel;
using amcom.DemoApp;
using amcom.DemoApp.CustomRenderers;
using amcom.DemoApp.Droid;
using Android.Graphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EditorWithNoLine), typeof(EditorWithNoLineRenderer))]
namespace amcom.DemoApp.Droid
{
	public class EditorWithNoLineRenderer : EditorRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null || this.Element == null)
				return;

			if (Control != null)
			{
				Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
			}
		}
	}
}