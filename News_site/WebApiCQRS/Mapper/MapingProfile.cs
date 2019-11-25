using AutoMapper;
using WebApiCQRS.Commands.CommentsCommands;
using WebApiEntity.Models;

namespace WebApiCQRS.Mapper
{
    public class MapingProfile : Profile
    {
        public MapingProfile()
        {
            CreateMap<AddComment, Comments>(); ;
        }
    }
}
