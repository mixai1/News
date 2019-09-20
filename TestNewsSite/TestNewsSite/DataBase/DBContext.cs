using Microsoft.EntityFrameworkCore;
using TestNewsSite.Models;

namespace TestNewsSite.DataBase
{
    public class DBContext : DbContext
    {
       
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }


        public DbSet<New> News { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }
    }
}
