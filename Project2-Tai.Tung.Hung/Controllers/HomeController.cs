using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Project2_TaiTungHung.Models;

namespace Project2_TaiTungHung.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Trang chủ
        public IActionResult TTHIndex()
        {
            return View("~/Views/TTHHome/TTHIndex.cshtml");
        }

        // Trang giới thiệu
        public IActionResult TTHAbout()
        {
            return View("~/Views/TTHHome/TTHAbout.cshtml");
        }

        // Trang lỗi
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml",
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
