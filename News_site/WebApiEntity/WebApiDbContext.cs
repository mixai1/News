using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiEntity.Models;

namespace WebApiEntity
{
    public class WebApiDbContext : IdentityDbContext
    {
        public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options)
        {

        }

        

        public DbSet<News> News { get; set; }
        public DbSet<Comments> Comments { get; set; }
    }
}
