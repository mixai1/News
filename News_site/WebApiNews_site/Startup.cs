using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApiNews_site.Extensions;

namespace WebApiNews_site
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureMapper();
            services.ConfigureCors();
            services.ConfigureSqlContext(Configuration);
            services.ConfigureJWT(Configuration);
            services.ConfigureSwagger();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.ConfigureMediatR();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
             
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseCors("CorsPolicy");
            app.UseSwagger();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
