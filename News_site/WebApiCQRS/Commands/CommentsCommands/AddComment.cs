using AutoMapper;
using MediatR;
using System;
using WebApiEntity.Models;

namespace WebApiCQRS.Commands.CommentsCommands
{
    public class AddComment : IRequest<bool>
    {
        public Comments Comments { get; set; }

        public AddComment(Comments comments)
        {
            Comments = comments;
        }
       
    }
 
}
