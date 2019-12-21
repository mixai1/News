using MediatR;
using Serilog;
using System.Threading;
using System.Threading.Tasks;
using WebApiEntity;

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
            _dbContext.News.Update(request.News);
            await _dbContext.SaveChangesAsync(cancellationToken);
            Log.Information("UpdataNews => completed successfully");
            return true;
        }
    }
}
