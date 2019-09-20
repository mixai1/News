using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestNewsSite.DataBase;
using TestNewsSite.Interfaces;
using TestNewsSite.Mocks;

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
            services.AddTransient<INewsRepository, NewsRepository>();
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
