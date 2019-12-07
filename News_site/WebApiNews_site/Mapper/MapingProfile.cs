using AutoMapper;
using WebApiEntity.Models;
using WebApiEntity.ModelsDto;

namespace WebApiNews_site.Mapper
{
    public class MapingProfile : Profile
    {
        public MapingProfile()
        {
            CreateMap<CommentsDto, Comments>();

        }
    }
}
