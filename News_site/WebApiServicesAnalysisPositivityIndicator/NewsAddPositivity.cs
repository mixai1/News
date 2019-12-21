using Core.InterfaceWebApiServicesAnalysisPositivity;
using MediatR;
using System;
using System.Threading.Tasks;
using WebApiCQRS.Commands.NewsCommands;
using WebApiCQRS.Querys.NewsQuerys;
using WebApiEntity.Models;

namespace WebApiServicesAnalysisPositivity
{
    public class NewsAddPositivity : INewsAddPositivity
    {
        private readonly IMediator _mediator;
        private readonly ILemmatization _lemmatization;
        public NewsAddPositivity(IMediator mediator, ILemmatization lemmatization)
        {
            _lemmatization = lemmatization;
            _mediator = mediator;
        }

        public async Task AddPositivInNews()
        {
            var result = await _mediator.Send(new GetListNewsWithoutIndex());
            foreach (var item in result)
            {
                item.IndexOfPositive = await _lemmatization.GetIndexOfPositivity(item);
               await _mediator.Send(new UpdateNews(item));
            }
        }
    }
}
