using Entity;
using Entity.NewsModels;

namespace Data.NewsRepository
{
    public class NewsRepository : EntityFrameworkRepositiry<News>
    {
        public NewsRepository(AppDbContext dbcontext) : base(dbcontext)
        {

        }
    }
}
