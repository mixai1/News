using MediatR;
using Serilog;
using System.Threading;
using System.Threading.Tasks;
using WebApiEntity;

namespace WebApiCQRS.Commands.CommentsCommands
{
    public class AddCommentHandler : IRequestHandler<AddComment, bool>
    {
        private readonly WebApiDbContext _dbContext;

        public AddCommentHandler(WebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(AddComment request, CancellationToken cancellationToken)
        {
            try
            {
                await _dbContext.Comments.AddAsync(request.Comments,cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
                Log.Information("WebApiCQRS,AddComment => completed successfully");
                return true;
            }
            catch (System.Exception ex)
            {
                Log.Error($"WebApiCQRS,AddComment => {ex.Message}");
                return false;
            }

        }
    }
}
