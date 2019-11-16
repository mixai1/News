using AutoMapper;
using MediatR;
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
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CreateUserHandler(WebApiDbContext dbContext, IMediator mediator, IMapper mapper)
        {
            _dbContext = dbContext;
            _mediator = mediator;
            _mapper = mapper;

        }


        public async Task<bool> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            var userExists = await _mediator.Send(new DoesExistUser(request.Email, request.Password), cancellationToken);
            if (userExists == null)
            {
                return false;
            }
            else
            {
                await _dbContext.Users.AddAsync(_mapper.Map<Users>(request));
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }
    }
}
