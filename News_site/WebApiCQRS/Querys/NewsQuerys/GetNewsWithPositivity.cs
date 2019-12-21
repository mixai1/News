using MediatR;
using System.Collections.Generic;
using WebApiEntity.Models;

namespace WebApiCQRS.Querys.NewsQuerys
{
    public class GetNewsWithPositivity : IRequest<IEnumerable<News>>
    {

    }
}
