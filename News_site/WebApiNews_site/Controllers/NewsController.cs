using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.InterfaceWebApiServicesAnalysisPositivity;
using Core.InterfaceWebApiServicesParsers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCQRS.Querys.NewsQuerys;

namespace WebApiNews_site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IWebApiGeneralParser _generalParser;
        private readonly IMediator _mediator;
        private readonly IConvertJsonAFINNToDictinary _convertJson;
        private readonly IGetFromStringToJsonResponsFromApi _sendText;
        private readonly IDeserializeRespons _deserialize;
        public NewsController(IWebApiGeneralParser generalParser, IMediator mediator, IConvertJsonAFINNToDictinary convertJson, IGetFromStringToJsonResponsFromApi sendText, IDeserializeRespons deserialize)
        {
            _generalParser = generalParser;
            _mediator = mediator;
            _convertJson = convertJson;
            _deserialize = deserialize;
            _sendText = sendText;
        }


        [HttpGet]
        [Route("GetNews")]
        public async Task<ActionResult> Get()
        {
            var result = await _mediator.Send(new AllNews());
            //var r = await _generalParser.AddNewsGeneralListNews();
            var res = await _convertJson.ConvertJsonToDictionary();
            List<string> list = new List<string>();
            

            //var respons = await _sendText.SendMessegeToApi("dsds");
            //var s = await _deserialize.Deserialize(respons);
            //foreach (var item in s)
            //{
            //    list.Add(item);
            //}
            return Ok(result);
        }
    }
}