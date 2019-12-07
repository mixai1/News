using MediatR;
using System;
using WebApiEntity.Models;

namespace WebApiCQRS.Querys.NewsQuerys
{
    public class GetNewsById : IRequest<News>
    {
        public Guid Id { get; set; }
        public GetNewsById(Guid id)
        {
            Id = id;
        }
    }
}
