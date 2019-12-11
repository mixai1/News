using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebApiEntity;
using WebApiEntity.Models;

namespace WebApiCQRS.Querys.NewsQuerys
{
    public class AllNewsHandler : IRequestHandler<AllNews, IEnumerable<News>>
    {
        private readonly WebApiDbContext _dbContext;
        public AllNewsHandler(WebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<News>> Handle(AllNews request, CancellationToken cancellationToken)
        {
            return await _dbContext.News.ToListAsync<News>(cancellationToken);
        }
    }
}
