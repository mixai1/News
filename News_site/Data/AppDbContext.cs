using Data.Models;
using Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Data
{
    public class AppDbContext : IdentityDbContext <MyUsers,MyRole,Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
           
        }



       public DbSet<News> News { get; set; }
       public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }

}
