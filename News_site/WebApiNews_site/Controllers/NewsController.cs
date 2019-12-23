using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using WebApiCQRS.Commands.NewsCommands;
using WebApiCQRS.Querys.NewsQuerys;

namespace WebApiNews_site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// GET,getNewsById
        /// </summary>
        /// <returns>Ok(news)</returns>
        [HttpGet]
        [Route("getNewsById")]
        public async Task<IActionResult> Get(Guid id)
        {
            try
            {
                var news = await _mediator.Send(new GetNewsById(id));
                Log.Information("News controller Actoin Get => completed successfully");
                return Ok(news);
            }
            catch (Exception ex)
            {

                Log.Error($"News controller Actoin Get => {ex.Message}");
            }
            return NotFound();
           
        }

        /// <summary>
        /// GET, getNewsPositivity
        /// </summary>
        /// <returns>Ok(listNews)</returns>
        [HttpGet]
        [Route("getnews")]
        public async Task<IActionResult> GetNewsPositivity()
        {
            try
            {
                var listNews = await _mediator.Send(new GetNewsWithPositivity());
                Log.Information("News controller Actoin GetNewsWithPositivity => completed successfully");
                return Ok(listNews);
            }
            catch (Exception ex)
            {
                Log.Error($"News controller Action GetNewsPositivity => {ex.Message}");
            }
            return NotFound("There is no positive news right now");
        }

        /// <summary>
        /// DELETE, DeleteNews
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("deletenews")]
        public async Task<IActionResult> DeleteNews(Guid id)
        {
            try
            {
                var news = await _mediator.Send(new DeleteNewsById(id));
                if (news)
                {
                    Log.Information("News controller Actoin DeleteNews => completed successfully");
                    return Ok();
                }   
            }
            catch (Exception ex)
            {
                Log.Error($"News controller Action Actoin DeleteNews => {ex.Message}");
            }
            return NotFound();
        }
    }
}