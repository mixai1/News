using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TestNewsSite.Interfaces;
using TestNewsSite.Models;
using TestNewsSite.UnitofWork;
using TestNewsSite.VeiwModels;

namespace TestNewsSite.Controllers
{
    public class NewsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public NewsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task<ActionResult> Index()
        {
            var IndexNews = await _unitOfWork.News.GetAllNewsAsync();
            return View(IndexNews);
        }

      
        public ActionResult AddNews()
        {
            var newViewModel = new NewViewModel()
            {
                Title = "Add News",
                ButtonName = "Add News",
                RedirectUrl = Url.Action("Index")
            };


            return View(newViewModel);
        }


        public async Task<ActionResult> FoundNewsIdofDeteils(Guid id)
        {
            var _newsId = await _unitOfWork.News.GetNewsIdAsync(id);


            return View(new NewViewModel { /*Id = _newsId.Id,*/ Heading = _newsId.Heading });
        }
        public ActionResult DeletNews(Guid id)
        {
             _unitOfWork.News.DeleteNewsId(id);

            return RedirectToAction("Index");
        }


        //public async Task<ActionResult> EditNews(NewViewModel newViewModel)
        //{
        //    var editNews = await _unitOfWork.News.UpdateNewsAsunc(newViewModel);

        //    var newsModel = new NewViewModel
        //    {
        //        Title = "Edit Student",
        //        ButtonName = "Save",
        //        RedirectUrl = Url.Action("Index", "Student"),
        //        Heading = editNews.Heading,
        //        Id = editNews.Id
        //    };

        //    return View(newsModel);
        //}




        [HttpPost]
        public async Task<ActionResult> SaveNews(NewViewModel newsViewModel, string redirectUrl)
        {
            if (newsViewModel is NewViewModel && newsViewModel !=null)
            {
                return View (newsViewModel);
            }
            var _news = await _unitOfWork.News.GetNewsIdAsync(newsViewModel.Id);

            if(_news != null)
            {
                await _unitOfWork.News.UpdateNewsAsunc(_news);
            }
            return RedirectLocal(redirectUrl);
        }
        [HttpPost]
        public async Task<ActionResult> AddNewNews(NewViewModel newsViewModel, string redirectUrl )
        {

            if(newsViewModel != null && newsViewModel is NewViewModel)
            {
                return View(newsViewModel);
            }
            var News = new New()
            {
                Heading = newsViewModel.Heading,
                
            };

            await _unitOfWork.News.AddNewsAsync(News);

            return RedirectLocal(redirectUrl);
        }


        private ActionResult RedirectLocal(string redirectUrl)
        {
            if (Url.IsLocalUrl(redirectUrl))
            {
                return Redirect(redirectUrl);
            }
            return RedirectToAction("Index", "News");
        }
    }
}