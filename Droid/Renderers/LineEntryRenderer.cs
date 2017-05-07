using System.ComponentModel;
using amcom.DemoApp.CustomRenderers;
using amcom.DemoApp.Droid;
using Android.Graphics;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(LineEntry), typeof(LineEntryRenderer))]
namespace amcom.DemoApp.Droid
{
	public class LineEntryRenderer : EntryRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (e.OldElement != null || this.Element == null)
				return;

			if (Control != null)
			{
				var view = (Element as LineEntry);
				if (view != null)
				{
					DrawBorder(view);
					SetFontSize(view);
					SetPlaceholderTextColor(view);
				}
			}
		}

		protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
		{
			base.OnElementPropertyChanged(sender, e);

			var view = (LineEntry)Element;

			if (e.PropertyName.Equals(view.BorderColor))
				DrawBorder(view);
			if (e.PropertyName.Equals(view.FontSize))
				SetFontSize(view);
			if (e.PropertyName.Equals(view.PlaceholderColor))
				SetPlaceholderTextColor(view);
		}

		void DrawBorder(LineEntry view)
		{
			if (view.BorderColor != Xamarin.Forms.Color.Black)
				Control.Background.SetColorFilter(view.BorderColor.ToAndroid(), PorterDuff.Mode.SrcAtop);
		}

		void SetPlaceholderTextColor(LineEntry view)
		{
			if (view.PlaceholderTextColor != Xamarin.Forms.Color.Default)
				Control.SetHintTextColor(view.PlaceholderTextColor.ToAndroid());
		}

		void SetFontSize(LineEntry view)
		{
			if (view.FontSize != Font.Default.FontSize)
			{
				Control.TextSize = view.Font.ToScaledPixel();
				Control.Typeface = view.Font.ToTypeface();
			}
		}
	}
}