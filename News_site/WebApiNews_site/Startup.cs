using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using WebApiNews_site.Extensions;

namespace WebApiNews_site
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Log.Logger = new LoggerConfiguration()
                .Enrich.WithProperty("Version","1.0.0")
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("logs\\log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

        }


        public void ConfigureServices(IServiceCollection services)
        {
            //Method from Extensios 

            services.ConfigureMapper();
            services.ConfigureCors();
            services.ConfigureSqlContext(Configuration);
            services.ConfigureJWT(Configuration);
            services.ConfigureSwagger();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.ConfigureMediatR();
            services.AddHangfire(Configuration);
            services.ConfigureIdentity();
            services.AddTarnsientParsers();

        }

       
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
            
            app.UseHangfireServer();
            app.UseAuthentication();
            app.UseCors("CorsPolicy");
            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json","Web(V1)");
            });
            app.UseHttpsRedirection();
            app.UseHangfireDashboard("/admin/hangfire");
            app.UseMvc();
        }
    }
}
