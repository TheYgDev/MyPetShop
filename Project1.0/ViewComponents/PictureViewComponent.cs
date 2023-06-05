using App.BLL.Services.Contracts;
using App.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Project1._0.ViewComponents
{
	public class PictureViewComponent : ViewComponent
	{

		public IViewComponentResult Invoke(string PicPath)
		{
			var stam = new Animal();
			if (PicPath == "")
			{
				return View("Add");
			}
			ViewBag.Path = PicPath;
				return View("Default");
		}
	}
}