using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebKillaDeco.Areas.Identity.Data;
using WebKillaDeco.Models;

namespace WebKillaDeco.Areas.Identity.Views.Home
{
    [Area("Identity")]
    [Authorize]
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
    }
}
