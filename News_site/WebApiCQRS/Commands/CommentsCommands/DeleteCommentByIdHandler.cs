using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebApiEntity;

namespace WebApiCQRS.Commands.CommentsCommands
{
    public class DeleteCommentByIdHandler : IRequestHandler<DeleteCommentById, bool>
    {
        private readonly WebApiDbContext _dbContext;

        public DeleteCommentByIdHandler(WebApiDbContext dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<bool> Handle(DeleteCommentById request, CancellationToken cancellationToken)
        {
            try
            {
                var comment = await _dbContext.Comments.FirstOrDefaultAsync(n => n.Id == request.Id);
                if (comment!=null)
                {
                    _dbContext.Comments.Remove(comment);
                   await _dbContext.SaveChangesAsync(cancellationToken);
                    Log.Information("WebApiCQRS,DeleteCommentById => completed successfully");
                    return true;
                }
                Log.Information("WebApiCQRS,DeleteCommentById => comment =null");
                return false;
                
            }
            catch (Exception ex)
            {
                Log.Error($"WebApiCQRS,DeleteComment => {ex.Message}");
                return false;
            }
        }
    }
}
