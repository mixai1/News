using Core;
using Data.NewsRepository;
using Data.UnitOfWork;
using Entity;
using Entity.IdetityModels;
using Entity.NewsModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Core.InterfaceParserServes;
using Services.ParsersServices;
using Services.EmailSenderServices;

namespace News_site
{
    public class Startup
    {

        public IConfiguration Configuration { get; }



        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
           services.AddDbContext<AppDbContext>(option =>
           option.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

           services.AddIdentity<MyUsers,MyRole>(op=> 
           {
               op.Password.RequireDigit = false;
               op.Password.RequiredLength = 5;
               op.Password.RequireUppercase = false;
               op.Password.RequireNonAlphanumeric = false;

           }). AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IGenericNewsRepository<Comment>, CommentRepository>();
            services.AddTransient<IGenericNewsRepository<News>, NewsRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.Configure<CookiePolicyOptions>(options =>
            {
               
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddTransient<IParser_S13, Parser_S13>();
            services.AddTransient<IParser_TutBy, Parser_TutBy>();
            services.AddTransient<IParser_Onliner, Parser_Onliner>();


            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
