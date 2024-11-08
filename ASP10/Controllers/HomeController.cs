using ASP10.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            ViewBag.ProductList = GetProductList();
            return View(new FormInfo());
        }

        [HttpPost]
        public ActionResult Register(FormInfo model)
        {
            ViewBag.ProductList = GetProductList();

            if (ModelState.IsValid)
            {
                ViewBag.Message = "Реєстрація успішна!";
                return Ok("Success");
            }

            return View(model);
        }

        private List<string> GetProductList()
        {
            return new List<string> { "JavaScript", "C#", "Java", "Python", "Основи" };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
