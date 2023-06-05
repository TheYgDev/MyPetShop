using App.BLL.Services.Contracts;
using App.DAL.Models;
using Castle.Core.Resource;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Project1._0.Controllers
{
	public class AnimalController : Controller
	{
		private readonly IUnitOfWork _service;
        public AnimalController(IUnitOfWork service)
        {
			_service = service;
		}
		[HttpGet]
        public IActionResult Index(int id)
		{
			var animal = _service.Animals.GetById(id);
			if (animal != null)
			{
				ViewBag.Comments = _service.Comments.GetAnimalComments(id);
				return View(animal);
			}
			else { return NotFound(); }
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddComment(Comment comment, int animalId)
		{
			if (ModelState.IsValid && comment.Text != string.Empty)
			{
				_service.Comments.AddAsync(comment, animalId);
				var succses = await _service.Complete();

                if (succses > 0)               
					return Json(new { success = true, message = "Comment added successfully.", commentText = comment.Text });
                else
					return Json(new { success = true, message = "Something went wrong Please try again later"});

			}

			return Json(new { success = false, message = "Please enter a valid comment thats longer then 3 chars and less then 50 chars." });
		}
	}
}
