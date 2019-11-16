using MediatR;
using System;
using System.Collections.Generic;
using WebApiEntity.Models;

namespace WebApiCQRS.Querys.CommentsQuerys
{
    public class GetCommentsById : IRequest<Comments>
    {
        public Guid CommentId { get; set; }
    }
}
