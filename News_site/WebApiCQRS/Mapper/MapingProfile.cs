using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApiCQRS.Commands.CommentsCommands;
using WebApiCQRS.Commands.UsersCommands;
using WebApiEntity.Models;

namespace WebApiCQRS.Mapper
{
    public class MapingProfile : Profile
    {
        public MapingProfile()
        {
            CreateMap<CreateUser, Users>();
            CreateMap<AddComment, Comments>(); ;
        }
    }
}
