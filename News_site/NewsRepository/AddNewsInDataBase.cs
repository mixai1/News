using Core;
using MediatR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using WebApiCQRS.Commands.NewsCommands;
using WebApiCQRS.Querys.NewsQuerys;
using WebApiEntity.Models;

namespace NewsRepository
{
    public class AddNewsInDataBase : IAddNewsInDataBase
    {
        private readonly IExistNewsInDataBase _existNews;
        private readonly IMediator _mediator;

        public AddNewsInDataBase(IExistNewsInDataBase existNews, IMediator mediator)
        {

            _mediator = mediator;
            _existNews = existNews;
        }


        public async Task AddNewsRangeDatabase()
        {
            try
            {
                var resultNews = await _existNews.ExceptNews();
                if(resultNews != null)
                {
                    Log.Information("Method AddNewsRangeDataBase => ");
                    await _mediator.Send(new AddListNews(resultNews));
                }

            }
            catch (Exception ex)
            {

                Log.Error($"Method AddNewsRangeDataBase => {ex.Message}");
           
            }
        }
    }
}
