using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using WebApiEntity;
using WebApiEntity.Models;

namespace WebApiCQRS.Querys.UsersQuerys
{
    public class DoesExistHandler : IRequestHandler<DoesExistUser, Users>
    {
        private readonly WebApiDbContext _dbContext;
        public DoesExistHandler(WebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Users> Handle(DoesExistUser request, CancellationToken cancellationToken)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == request.Email);

        }


    }
}
