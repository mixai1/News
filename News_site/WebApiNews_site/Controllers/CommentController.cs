using System;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using WebApiCQRS.Commands.CommentsCommands;
using WebApiCQRS.Querys.CommentsQuerys;
using WebApiCQRS.Querys.NewsQuerys;
using WebApiEntity.Models;
using WebApiEntity.ModelsDto;

namespace WebApiNews_site.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserManager<IdentityUser> _userManager;
        public CommentController(IMediator mediator, UserManager<IdentityUser> userManager)
        {
            _mediator = mediator;
            _userManager = userManager;
        }

        /// <summary>
        /// api/GetCommentById
        /// </summary>
        /// <param name="commentsById"></param>
        /// <returns>Ok(comment)</returns>
        [HttpGet]
        [Route("getcomment")]
        public async Task<IActionResult> GetCommentsById([FromBody]Guid id)
        {
            try
            {
                var comment = await _mediator.Send(new GetCommentsById(id));
                if (comment != null)
                {
                    Log.Information("Action GetCommentById => completed successfully ");
                    return Ok(comment);
                }
                return NotFound();
            }
            catch (Exception ex)
            {
                Log.Error($"Action GetCommentById {ex.Message}");
                return NotFound();
            }
        }

        /// <summary>
        /// api/addcomment
        /// </summary>
        /// <param name="commentModel"></param>
        /// <param name="newsId"></param>
        /// <returns>Ok(comment)</returns>
        [HttpPost]
        [Route("addcomment")]
        public async Task<IActionResult> PostComment([FromBody]CommentsDto commentModel, Guid newsId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var author = _userManager.FindByIdAsync(User.FindFirst(ClaimTypes.NameIdentifier).Value).Result;
                    var comment = new Comments()
                    {
                        Author = author.UserName,
                        Body = commentModel.Body,
                        CreateDate = DateTime.UtcNow.ToLocalTime(),
                        News = await _mediator.Send(new GetNewsById(newsId))
                    };

                    var result = await _mediator.Send(new AddComment(comment));

                    if (result)
                    {
                        Log.Information("Action PostComment => completed successfully ");
                        return Ok(comment);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Action PostComment => {ex.Message}");
            }
            return BadRequest();
        }

        /// <summary>
        /// api/deletecomment
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ok()</returns>
        [HttpDelete]
        [Authorize(Roles = "admin")]
        [Route("deletcomment")]
        public async Task<IActionResult> DeleteCommentById([FromBody] Guid id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteCommentById(id));
                if (result)
                {
                    Log.Information("Action DeleteCommentById => completed successfully ");
                    return Ok();
                }

            }
            catch (Exception ex)
            {
                Log.Error($"Action DeleteCommentById => {ex.Message}");
            }

            return NotFound();
        }
    }
}