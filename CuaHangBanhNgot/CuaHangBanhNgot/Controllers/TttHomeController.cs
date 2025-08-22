using System.Diagnostics;
using CuaHangBanhNgot.Models;
using Microsoft.AspNetCore.Mvc;

namespace CuaHangBanhNgot.Controllers
{
    public class TttHomeController : Controller
    {
        private readonly ILogger<TttHomeController> _logger;

        public TttHomeController(ILogger<TttHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult TttIndex()
        {
            return View();
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
