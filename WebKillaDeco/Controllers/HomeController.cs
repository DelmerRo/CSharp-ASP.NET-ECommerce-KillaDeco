using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System.Diagnostics;
using WebKillaDeco.Areas.Identity.Data;
using WebKillaDeco.Models;

namespace WebKillaDeco.Controllers
{
    public class HomeController : Controller
    {
        public readonly KillaDbContext _context;
        public readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, KillaDbContext context)
        {
            _context = context;
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
