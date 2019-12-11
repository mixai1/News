using Core;
using MediatR;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCQRS.Querys.NewsQuerys;
using WebApiEntity.Models;
using Serilog;

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
                var AllNewsFromDb = await _mediator.Send(new AllNews());
                var AllNewsFromParsers = _generalParser.AllNewsListWithoutRepetition;

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
