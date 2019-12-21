using MediatR;
using System;

namespace WebApiCQRS.Commands.NewsCommands
{
    public class DeleteNewsById : IRequest<bool>
    {
        public Guid Id { get; set; }
        public DeleteNewsById(Guid id)
        {
            Id = id;
        }
    }
}
