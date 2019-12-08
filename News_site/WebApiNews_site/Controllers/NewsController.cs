using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiNews_site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IWebApiGeneralParser _generalParser;
        public NewsController(IWebApiGeneralParser generalParser)
        {
            _generalParser = generalParser;
        }

        public async Task<ActionResult> Get()
        {
           // _generalParser.AllNewsListWithoutRepetition
            return Ok();
        }
    }
}