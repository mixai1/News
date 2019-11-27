using System;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Entity.NewsModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using News_site.NewsVIewModels;

namespace News_site.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentController(IUnitOfWork unitofwork)
        {
            _unitOfWork = unitofwork;
        }



        [HttpPost]
        public async Task<IActionResult> AddComment([FromBody] CommentViewModel commentModel)
        {
            var comment = new Comment()
            {
                Content = commentModel.Body,
                DateTime = DateTime.SpecifyKind(
              DateTime.UtcNow,
              DateTimeKind.Utc),
            };


            await _unitOfWork.Comments.AddAsync(comment);
            await _unitOfWork.SaveAsync();

            return Json(comment.Content);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteComment([FromBody] Guid id)
        {
            await _unitOfWork.Comments.DeleteId(id);
            await _unitOfWork.SaveAsync();

            return Ok();
        }


    }
}