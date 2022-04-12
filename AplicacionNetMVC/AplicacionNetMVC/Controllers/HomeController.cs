using AplicacionNetMVC.Datos;
using AplicacionNetMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AplicacionNetMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDBContext _contexto;

        public HomeController(ApplicationDBContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
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