using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TestNewsSite.Interfaces;

namespace TestNewsSite.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsRepository _new;
        public NewsController(INewsRepository news)
        {
            _new = news; 
        }
        // GET: News
        public async Task<ActionResult> Index()
        {
            var IndexNew = await _new.GetAllNewsAsync();
            return View(IndexNew);
        }

        // GET: News/Add
        public ActionResult AddNew()
        {
            //var newViewModel = new NewViewModel();

            return View();
        }

        
    }
}