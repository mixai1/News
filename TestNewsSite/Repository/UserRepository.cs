using TestNewsSite.DataBase;
using TestNewsSite.Models;

namespace TestNewsSite.Repository
{
    public class UserRepository : EntityFrameworkRepositiry<User>
    {
        public UserRepository(DBContext dbcontext) : base(dbcontext)
        {

        }
    }
}
