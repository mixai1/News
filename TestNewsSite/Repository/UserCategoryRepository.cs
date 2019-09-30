using TestNewsSite.DataBase;
using TestNewsSite.Models;

namespace TestNewsSite.Repository
{
    public class UserCategoryRepository : EntityFrameworkRepositiry<UserCategory>
    {
        public UserCategoryRepository(DBContext dbcontext) : base(dbcontext)
        {

        }
    }
}
