using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WebApiCQRS.Querys.UsersQuerys;
using WebApiEntity;
using WebApiEntity.Models;

namespace WebApiCQRS.Commands.UsersCommands
{
    public class CreateUserHandler : IRequestHandler<CreateUser, bool>
    {
        private readonly WebApiDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateUserHandler(WebApiDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;

        }


        public async Task<bool> Handle(CreateUser request, CancellationToken cancellationToken)
        {
           var userExists = await _dbContext.Users.FirstOrDefaultAsync(u=>u.Email == request.Email);
            if (userExists == null)
            {
                await _dbContext.Users.AddAsync(_mapper.Map<Users>(request));
                await _dbContext.SaveChangesAsync();
                return true;
              
            }


            return false;
           
        }
    }
}
