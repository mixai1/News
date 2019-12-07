using MediatR;
using System;

namespace WebApiCQRS.Commands.CommentsCommands
{
    public class DeleteCommentById : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DeleteCommentById(Guid id)
        {
            Id = id;
        }
    }
}
