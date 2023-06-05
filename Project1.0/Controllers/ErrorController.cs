using Microsoft.AspNetCore.Mvc;

namespace Project1._0.Controllers
{
	public class ErrorController : Controller
	{

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Error404()
		{
			return View();
		}
	}
}
