using MediatR;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebApiEntity;

namespace WebApiCQRS.Commands.NewsCommands
{
    public class AddListNewsHandler : IRequestHandler<AddListNews, bool>
    {
        
        private readonly WebApiDbContext _dbContext;
        public AddListNewsHandler( WebApiDbContext dbContext)
        {
           
            _dbContext = dbContext;
        }

        public async Task<bool> Handle(AddListNews request, CancellationToken cancellationToken)
        {
            try
            {
                await _dbContext.News.AddRangeAsync(request.NewsList, cancellationToken);
                await _dbContext.SaveChangesAsync(cancellationToken);
                Log.Information("WebApiCQRS, AddListNews => completed successfully");
                return true;

            }
            catch (Exception ex)
            {
                Log.Error($"WebApiCQRS, AddListNews => {ex.Message}");
                return false;
            }
               

        }  
    }
}
