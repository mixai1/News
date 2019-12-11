using MediatR;
using System.Collections.Generic;
using WebApiEntity.Models;

namespace WebApiCQRS.Querys.NewsQuerys
{
    public class AllNews : IRequest<IEnumerable<News>>
    {
    
    }
}
