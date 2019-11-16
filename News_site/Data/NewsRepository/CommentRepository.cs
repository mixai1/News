using Entity;
using Entity.NewsModels;

namespace Data.NewsRepository
{
    public class CommentRepository : EntityFrameworkRepositiry<Comment>
    {
        public CommentRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
