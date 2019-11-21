using System.Threading.Tasks;
using Core;
using Entity.IdetityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using News_site.NewsViewModels;

namespace News_site.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<MyUsers> _userManager;

        public HomeController(IUnitOfWork unitOfWork, UserManager<MyUsers> userManager)
        {
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            
        }
        public async Task<IActionResult> Index()
        {
            var result = await _unitOfWork.News.GetAllAsync();

            var newsView = new IndexNewsModel()
            {
                News = result
            };
            return View(newsView);
        }

     
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

    }
}
