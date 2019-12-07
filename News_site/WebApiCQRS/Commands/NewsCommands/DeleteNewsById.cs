using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

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
