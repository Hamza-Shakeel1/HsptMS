using HsptMS.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HsptMS.Controllers
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

		public IActionResult Privacy()
		{
			return View();
		}
        public IActionResult AboutMe()
        {
            return View();
        }
		public IActionResult ContactUs() { return View(); }

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

		public IActionResult ContactUsConfirmed()
		{
			return View();
		}
    }
}
