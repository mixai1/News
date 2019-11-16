using AutoMapper;
using MediatR;
using System;
using WebApiEntity.Models;

namespace WebApiCQRS.Commands.CommentsCommands
{
    public class AddComment : IRequest<bool>
    {
        public Guid CommentId { get; set; }
        public string Body { get; set; }
        public string Author { get; set; }
    }
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddComment, Comments>();
        }
    }
}
