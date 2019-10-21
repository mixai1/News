using Data.Models;

namespace Data.NewsRepository
{
    public class CommentRepository : EntityFrameworkRepositiry<Comment>
    {
        public CommentRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
