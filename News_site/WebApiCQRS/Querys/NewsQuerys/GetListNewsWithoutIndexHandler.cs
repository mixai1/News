using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiEntity;
using WebApiEntity.Models;

namespace WebApiCQRS.Querys.NewsQuerys
{
    public class GetListNewsWithoutIndexHandler : IRequestHandler<GetListNewsWithoutIndex, IEnumerable<News>>
    {
        private readonly WebApiDbContext _dbContext;
        public GetListNewsWithoutIndexHandler(WebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<News>> Handle(GetListNewsWithoutIndex request, CancellationToken cancellationToken)
        {
            var result =  await _dbContext.News.Where(n => n.IndexOfPositive == null).ToListAsync();
            Log.Information("GetListNewsWithoutIndex => completed successfully");
            return result;
        }
    }
}
