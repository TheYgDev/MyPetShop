using Microsoft.AspNetCore.Mvc;
using App.BLL.Services.Contracts;
using App.DAL.Models;

namespace Project1._0.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _service;
        public HomeController(IUnitOfWork serv)
        {
            _service = serv;
        }
        public IActionResult Index()
        {
			IEnumerable<Animal> animals;
			animals = _service.Animals.GetMostRatedAnimales(2);
			return View(animals);

		}
        public  IActionResult Catalog()
        {
			IEnumerable<Animal> animals =_service.Animals.Get();
            return View(animals);
        }

    }
}
