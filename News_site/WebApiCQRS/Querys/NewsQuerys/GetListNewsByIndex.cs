using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiEntity.Models;

namespace WebApiCQRS.Querys.NewsQuerys
{
    public class GetListNewsByIndex : IRequest<IEnumerable<News>>
    {
        public double Index { get; set; }
        public GetListNewsByIndex(double index)
        {
            Index = index;
        }
    }
}
