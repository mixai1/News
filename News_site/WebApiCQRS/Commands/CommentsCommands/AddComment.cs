using AutoMapper;
using MediatR;
using System;
using WebApiEntity.Models;

namespace WebApiCQRS.Commands.CommentsCommands
{
    public class AddComment : IRequest<bool>
    {
        public string Body { get; }
        public string Author { get; }

       
    }
 
}
