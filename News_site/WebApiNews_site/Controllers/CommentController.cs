using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCQRS.Commands.CommentsCommands;
using WebApiCQRS.Querys.CommentsQuerys;

namespace WebApiNews_site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="commentsById"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCommentById")]
        public async Task<IActionResult> GetCommentsById([FromBody]GetCommentsById commentsById)
        {

            var comment = await _mediator.Send(commentsById);
            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("addcomment")]
        public async Task<IActionResult> PostComment([FromBody]AddComment comment)
        {
            var result = await _mediator.Send(comment);
            if (result)
            {
                return StatusCode(201);
            }

            return BadRequest();

        }


    }
}