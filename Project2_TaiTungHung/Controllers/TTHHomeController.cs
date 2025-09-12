using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Project2_TaiTungHung.Models;

namespace Project2_TaiTungHung.Controllers
{
    public class TTHHomeController : Controller
    {
        private readonly ILogger<TTHHomeController> _logger;

        public TTHHomeController(ILogger<TTHHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult TTHIndex()
        {
            return View();
        }

        public IActionResult TTHAbout()
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
