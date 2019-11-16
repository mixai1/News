using AutoMapper;
using MediatR;
using WebApiEntity.Models;

namespace WebApiCQRS.Commands.UsersCommands
{
    public class CreateUser : IRequest<bool>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class MapingProfile : Profile
    {
        public MapingProfile()
        {
            CreateMap<CreateUser, Users>();
        }
    }
}
