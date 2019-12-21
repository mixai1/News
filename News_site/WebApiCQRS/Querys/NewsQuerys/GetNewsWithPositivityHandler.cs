using MediatR;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiEntity;
using WebApiEntity.Models;

namespace WebApiCQRS.Querys.NewsQuerys
{
    public class GetNewsWithPositivityHandler : IRequestHandler<GetNewsWithPositivity, IEnumerable<News>>
    {
        private readonly WebApiDbContext _dbContext;
        public GetNewsWithPositivityHandler(WebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<News>> Handle(GetNewsWithPositivity request, CancellationToken cancellationToken)
        {
            var result = await _dbContext.News.Where(n => n.IndexOfPositive > 0.001).OrderBy(i=>i.IndexOfPositive).ToListAsync();
            Log.Information("GetNewsWithPositivity => completed successfully");
            return result;
        }
    }
}
