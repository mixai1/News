using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestNewsSite.DataBase;
using TestNewsSite.Interfaces;
using TestNewsSite.Models;
using TestNewsSite.Repository;
using TestNewsSite.UnitofWork;

namespace TestNewsSite
{
    public class Startup
    {
        private IConfigurationRoot _configurationString;
        public Startup(IHostingEnvironment hostingEnv)
        {
            _configurationString = new ConfigurationBuilder().
                SetBasePath(hostingEnv.ContentRootPath).
                AddJsonFile("DBsettings.json").Build();
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<IGenericNewsRepository<Admin>,AdminRepository>();
            services.AddTransient<IGenericNewsRepository<Comment>,CommentRepository>();
            services.AddTransient<IGenericNewsRepository<New>,NewsRepository>();
            services.AddTransient<IGenericNewsRepository<User>,UserRepository>();
            services.AddTransient<IGenericNewsRepository<UserCategory>,UserCategoryRepository>();
            services.AddTransient<IUnitOfWork,UnitOfWork>();
            services.AddDbContext<DBContext>(p => p.UseSqlServer(_configurationString.
                GetConnectionString("DefaultConnection")));
        }

       
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
        }
    }
}
