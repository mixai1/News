using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiEntity.Models;

namespace WebApiCQRS.Querys.NewsQuerys
{
    public class GetListNewsWithoutIndex : IRequest<IEnumerable<News>>
    {

    }
}
