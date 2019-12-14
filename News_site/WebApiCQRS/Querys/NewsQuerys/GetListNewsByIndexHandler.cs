using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApiEntity;
using WebApiEntity.Models;

namespace WebApiCQRS.Querys.NewsQuerys
{
    public class GetListNewsByIndexHandler : IRequestHandler<GetListNewsByIndex, IEnumerable<News>>
    {
        private readonly WebApiDbContext _dbContext;
        public GetListNewsByIndexHandler(WebApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<News>> Handle(GetListNewsByIndex request, CancellationToken cancellationToken)
        {
            var result = _dbContext.News.Where(n => n.IndexOfPositive == request.Index).ToList();
            return result;
        }
    }
}
