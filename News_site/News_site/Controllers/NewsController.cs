using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Core.InterfaceParserServes;
using Microsoft.AspNetCore.Authorization;
using Core;

namespace News_site.Controllers
{
    public class NewsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IParser_S13 _parser_S13;
        private readonly IParser_Onliner _parser_Onliner;

       // private readonly IParser_TutBy _parser_TutBy;

        public NewsController(IParser_S13 parser_S13,IParser_Onliner parser_Onliner,IUnitOfWork unitOfWork)
        {
            _parser_S13 = parser_S13;
            _parser_Onliner = parser_Onliner;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> AddNews()
        {
            var news_S13 = await _parser_S13.GetNewsFromUrl();
            await _parser_S13.AddRangeAsync(news_S13);

            var news_Onliner = await _parser_Onliner.GetNewsFromUrl();
            await _parser_Onliner.AddRangeAsync(news_Onliner);

            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index", "Home");
        }

        
        [HttpPost]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _unitOfWork.News.DeleteId(id);
            await _unitOfWork.SaveAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}