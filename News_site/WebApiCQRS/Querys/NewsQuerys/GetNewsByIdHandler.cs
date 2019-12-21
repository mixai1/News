using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;
using WebApiEntity;
using WebApiEntity.Models;

namespace WebApiCQRS.Querys.NewsQuerys
{
    public class GetNewsByIdHandler : IRequestHandler<GetNewsById, News>
    {
        private readonly WebApiDbContext _dbContext;
        public GetNewsByIdHandler(WebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<News> Handle(GetNewsById request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.News.FirstOrDefaultAsync(n => n.Id == request.Id,cancellationToken);
            Log.Information("GetNewsById => completed successfully");
            return result;
        }
    }
}
