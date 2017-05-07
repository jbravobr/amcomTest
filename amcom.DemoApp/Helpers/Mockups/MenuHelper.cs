using System.Collections.Generic;

namespace amcom.DemoApp
{
	public static class MenuHelper
	{
		public static List<Menu> menus = new List<Menu>();

		public static List<Menu> BulkMenuList()
		{
			return ConfigureMenus(menus);
		}

		static List<Menu> ConfigureMenus(List<Menu> menus)
		{
			var menuPhotosGallery = new Menu
			{
				Name = "Fotos",
				Order = 2,
				Icon = GrialShapesFont.InsertPhoto,
				MenuType = MenuType.Photo.GetDescription()
			};
			menus.Add(menuPhotosGallery);

			var menuRegister = new Menu
			{
				Name = "Novo Registro",
				Order = 1,
				Icon = GrialShapesFont.Create,
				MenuType = MenuType.Register.GetDescription()
			};
			menus.Add(menuRegister);

			var menuQuit = new Menu
			{
				Name = "Sair",
				Order = 4,
				Icon = GrialShapesFont.Power,
				MenuType = MenuType.Quit.GetDescription()
			};
			menus.Add(menuQuit);

			return menus;
		}
	}
}