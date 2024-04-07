using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TestTaskForIntravision.WebMvc.Models;

namespace TestTaskForIntravision.WebMvc.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        public IActionResult Index()
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
