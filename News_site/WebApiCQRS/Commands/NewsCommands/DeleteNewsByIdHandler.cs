using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApiEntity;

namespace WebApiCQRS.Commands.NewsCommands
{
    public class DeleteNewsByIdHandler : IRequestHandler<DeleteNewsById, bool>
    {
        private readonly WebApiDbContext _dbContext;
        public DeleteNewsByIdHandler(WebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(DeleteNewsById request, CancellationToken cancellationToken)
        {
            try
            {
                var news = await _dbContext.News.FirstOrDefaultAsync(n => n.Id == request.Id);
                if (news != null)
                {
                    _dbContext.News.Remove(news);
                    await _dbContext.SaveChangesAsync(cancellationToken);
                    Log.Information("WebApiCQRS,DeleteCommentById => completed successfully");
                    return true;
                }
                Log.Information("WebApiCQRS,DeleteNewsById => news = null");
                return false;

            }
            catch (Exception ex)
            {

                Log.Error($"WebApiCQRS,DeleteNews => {ex.Message}");
                return false;
            }
        }
    }
}
