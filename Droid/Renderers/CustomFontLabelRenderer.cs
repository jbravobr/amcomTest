using System;
using UXDivers.Artina.Shared;
using Xamarin.Forms;

namespace amcom.DemoApp.Droid
{
	public class CustomFontLabelRenderer : ArtinaCustomFontLabelRenderer
	{
		static readonly string[] CustomFontFamily = { "grialshapes", "FontAwesome", "Ionicons" };
		static readonly Tuple<FontAttributes, string>[][] CustomFontFamilyData = {
			new [] {
				new Tuple<FontAttributes, string>(FontAttributes.None, "grialshapes.ttf"),
				new Tuple<FontAttributes, string>(FontAttributes.Bold, "grialshapes.ttf"),
				new Tuple<FontAttributes, string>(FontAttributes.Italic, "grialshapes.ttf")
			}
		};

		protected override bool CheckIfCustomFont(string fontFamily, FontAttributes attributes, out string fontFileName)
		{
			for (int i = 0; i < CustomFontFamily.Length; i++)
			{
				if (string.Equals(fontFamily, CustomFontFamily[i], StringComparison.InvariantCulture))
				{
					var fontFamilyData = CustomFontFamilyData[i];

					for (int j = 0; j < fontFamilyData.Length; j++)
					{
						var data = fontFamilyData[j];
						if (data.Item1 == attributes)
						{
							fontFileName = data.Item2;
							return true;
						}
					}

					break;
				}
			}

			fontFileName = null;
			return false;
		}
	}
}