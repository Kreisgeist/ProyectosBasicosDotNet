using InyeccionDependenciasMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InyeccionDependenciasMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Models.ControlUsuariosContext _db;

        public HomeController(ILogger<HomeController> logger, Models.ControlUsuariosContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            var lst = (from u in _db.Users
                       where u.Status == true
                       select u).ToList();

            return View(lst);
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
