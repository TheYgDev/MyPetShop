using App.BLL.Services.Contracts;
using App.DAL.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;


namespace Project1._0.Controllers
{
	public class AdminController : Controller
	{
		private readonly IUnitOfWork _service;
		public AdminController(IUnitOfWork service)
		{
			_service = service;
		}

		public IActionResult Index()
		{
			IEnumerable<Animal> animals = _service.Animals.Get();
			return View(animals);
		}

		[HttpGet]
		public IActionResult AnimalEdit(int id)
		{
			var animal = _service.Animals.GetById(id);
			if (animal != null)
			{
				ViewBag.Categories = _service.Categories.Get();
				return View(animal);
			}
			else { return NotFound(); }
		}

		[HttpGet]
		public IActionResult AnimalAdd()
		{
			ViewBag.Categories = _service.Categories.Get();
			return View("AnimalEdit");
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> AddAnimal(Animal animal, IFormFile PictureName)
		{
			ModelState.Remove("PictureName");

			if (ModelState.IsValid)
			{
				if (PictureName == null)
					return Json(new { success = false, message = "No Picture Was Added" });

				if (_service.Animals.IsAlreadyIn(animal.Name!))
					return Json(new { success = false, message = $"The Animal {animal.Name} already exists" });

				var fileExtension = Path.GetExtension(PictureName.FileName);
				var imageName = animal.Name + fileExtension;

				animal.PictureName = imageName;
				var added = _service.Animals.AddAsync(animal);
				if (!added)
					return Json(new { success = false, message = "Please Enter all Fields To add an animal" });

				var sucsses = await _service.Complete();
				if (sucsses > 0)
				{
					var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", imageName);
					using (var fileStream = new FileStream(filePath, FileMode.Create))
					{
						PictureName.CopyTo(fileStream);
					}
					return Json(new { success = true, message = $"{animal.Name} Was Added" });

				}
				return Json(new { success = false, message = "Something Went wrong please try again later" });
			}
			return Json(new { success = false, message = "Please Enter all Fields To add an animal" });

		}



		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditAnimal(Animal animal, IFormFile PictureName, string oldPath)
		{
			ModelState.Remove("PictureName");

			if (ModelState.IsValid)
			{
				var imageName = oldPath;
				var extestion = Path.GetExtension(oldPath);
				var ImageNameWithoutExtension = Path.GetFileNameWithoutExtension(oldPath);



				if (animal.Name!.ToLower() != ImageNameWithoutExtension.ToLower())
				{
					ImageNameWithoutExtension = animal.Name;
				}
				if (PictureName != null)
				{
					extestion = Path.GetExtension(PictureName.FileName);
				}

				imageName = ImageNameWithoutExtension + extestion;

				animal.PictureName = imageName;

				var edited = _service.Animals.EditAsync(animal);

				if (!edited)
				{
					return Json(new { success = false, message = "Please Enter all Fields Correctly" });
				}

				var sucsess = await _service.Complete();
				if (sucsess > 0)
				{
					var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", imageName);
					var OldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", oldPath);
					if (animal.PictureName.ToLower() != oldPath.ToLower())
					{
						ChangeImgPath(OldPath, path);
					}
					if (PictureName != null)
					{
						DeleteImg(oldPath);
						CreateImg(path, PictureName!);
					}


					return Json(new { success = true, message = $"{animal.Name} Was Edited" });
				}

			}
			return Json(new { success = false, message = "Please Enter all Fields Correctly" });
		}


		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Delete(int id)
		{
			var animal = _service.Animals.Delete(id);
			var sucsess = await _service.Complete();
			if (animal != null)
				DeleteImg(animal.PictureName!);

			return RedirectToAction("Index");
		}

		public void DeleteImg(string filePath)
		{
			var oldFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", filePath);
			if (System.IO.File.Exists(oldFilePath))
			{
				System.IO.File.Delete(oldFilePath);
			}
		}
		public string getImgName(Animal animal, string extension)
		{
			var imageName = animal.Name + extension;
			return imageName;

		}
		public void CreateImg(string filePath, IFormFile PictureName)
		{
			using (var fileStream = new FileStream(filePath, FileMode.Create))
			{
				PictureName.CopyTo(fileStream);
			}
		}
		public void ChangeImgPath(string oldPath, string NewPath)
		{
			System.IO.File.Move(oldPath, NewPath);
		}


	}
}
