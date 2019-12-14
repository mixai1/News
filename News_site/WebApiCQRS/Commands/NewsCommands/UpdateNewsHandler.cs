using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Threading;
using System.Threading.Tasks;
using WebApiEntity;
using WebApiEntity.Models;

namespace WebApiCQRS.Commands.NewsCommands
{
    public class UpdateNewsHandler : IRequestHandler<UpdateNews, bool>
    {
        private readonly WebApiDbContext _dbContext;
        public UpdateNewsHandler(WebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(UpdateNews request, CancellationToken cancellationToken)
        {
            //_dbContext.News.Attach(request.News);
            //_dbContext.Entry(request.News).State = EntityState.Modified;
            _dbContext.News.Update(request.News);
            await _dbContext.SaveChangesAsync(cancellationToken);
           Log.Information("UpdataNews => completed successfully");
            return true;
        }
    }
}
