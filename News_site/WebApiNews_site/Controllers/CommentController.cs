using System;
using System.Threading.Tasks;
using AutoMapper;
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
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
       // private readonly UserManager<IdentityUser> _userManager;
        public CommentController(IMediator mediator/*, UserManager<IdentityUser> userManager, IMapper mapper*/)
        {
            _mediator = mediator;
            //_userManager = userManager;
            ///_mapper = mapper;
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
                    var comment = _mapper.Map<Comments>(new CommentsDto
                    {
                        Author = null,  //await _userManager.FindByIdAsync()
                        Body = commentModel.Body,
                        CreateDate = DateTime.Today,
                        News = await _mediator.Send(new GetNewsById(newsId))

                    });
  
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
        [Route("deletcomment")]
        public async Task<IActionResult> DeleteCommentById([FromBody] Guid id)
        {
            try
            {
              var result =  await _mediator.Send(new DeleteCommentById(id));
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

            return BadRequest();
        }

    }
}