using Microsoft.AspNetCore.Mvc;

namespace Project2_TaiTungHung.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
