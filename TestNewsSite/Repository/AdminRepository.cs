using TestNewsSite.DataBase;
using TestNewsSite.Models;

namespace TestNewsSite.Repository
{
    public class AdminRepository : EntityFrameworkRepositiry<Admin>
    {
        public AdminRepository(DBContext dbcontext) : base(dbcontext)
        {

        }
    }
}
