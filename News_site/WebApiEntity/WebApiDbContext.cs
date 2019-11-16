using Microsoft.EntityFrameworkCore;
using WebApiEntity.Models;

namespace WebApiEntity
{
    public class WebApiDbContext : DbContext
    {
        public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options)
        {

        }

        public DbSet<News> News { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
