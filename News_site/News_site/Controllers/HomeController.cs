using System.Collections.Generic;
using System.Diagnostics;
using Data.Models;
using Data.UnitOfWork;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using News_site.Models;

namespace News_site.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }

        [Authorize]
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
