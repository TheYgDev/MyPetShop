using App.BLL.Services.Contracts;
using App.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace Project1._0.ViewComponents
{
	public class CategoryMenuViewComponent : ViewComponent
	{

		private readonly IUnitOfWork _service;
		public CategoryMenuViewComponent(IUnitOfWork service)
		{
			_service = service;
		}

		public async Task<IViewComponentResult> InvokeAsync(bool withSearch)
		{
			var categories = await GetCategoriesAsync();
			if (withSearch)
				return View("Default", categories);

			return View("WithoutSearch", categories);


		}
		private async Task<IEnumerable<Category>> GetCategoriesAsync()
		{
			var result = await Task.Run(() => _service.Categories.Get());
			return result;
		}


	}
}

