using TestNewsSite.DataBase;
using TestNewsSite.Models;

namespace TestNewsSite.Repository
{
    public class NewsRepository : EntityFrameworkRepositiry<New>
    {
        public NewsRepository(DBContext dbcontext):base(dbcontext)
        {

        }
    }
}
