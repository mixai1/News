using TestNewsSite.DataBase;
using TestNewsSite.Models;

namespace TestNewsSite.Repository
{
    public class CommentRepository : EntityFrameworkRepositiry<Comment>
    {
        public CommentRepository(DBContext dbcontext): base(dbcontext)
        {

        }
    }
}
