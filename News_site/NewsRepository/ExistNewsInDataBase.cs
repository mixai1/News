using MediatR;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCQRS.Querys.NewsQuerys;
using WebApiEntity.Models;
using Serilog;
using Core.InterfaceWebApiNewsRepository;
using Core.InterfaceWebApiServicesParsers;

namespace WebApiNewsRepository
{
    public class ExistNewsInDataBase : IExistNewsInDataBase
    {
        private readonly IWebApiGeneralParser _generalParser;
        private readonly IMediator _mediator;

        public ExistNewsInDataBase(IWebApiGeneralParser generalParser, IMediator mediator)
        {
            _generalParser = generalParser;
            _mediator = mediator;
        }

        public async Task<IEnumerable<News>> ExceptNews()
        {
            try
            {
                var AllNewsFromParsers = await _generalParser.AddNewsGeneralListNews();
                var AllNewsFromDb = await _mediator.Send(new AllNews());

                var exceptNews = AllNewsFromParsers.Except<News>(AllNewsFromDb);

                Log.Information("Method ExceptNews  => completed successfully");

                return exceptNews;

            }
            catch (Exception ex)
            {
                Log.Information($"Method ExceptNews  => {ex.Message}");
                return null;
            }

        }
    }
}
