using MediatR;
using System.Collections.Generic;
using WebApiEntity.Models;

namespace WebApiCQRS.Commands.NewsCommands
{
   public class UpdateNews : IRequest<bool>
    {
        public News News { get; set; }
        public UpdateNews(News news)
        {
            News = news;  
        }
    }
}
