using AutoMapper;
using Core.InterfaceWebApiNewsRepository;
using Core.InterfaceWebApiServicesAnalysisPositivity;
using Core.InterfaceWebApiServicesParsers;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Services.WebApiParsersServices;
using System;
using System.Text;
using WebApiEntity;
using WebApiNewsRepository;
using WebApiServicesAnalysisPositivity;

namespace WebApiNews_site.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection service)
        {
            service.AddCors(option =>
            option.AddPolicy("CorsPolicy",
            builder => builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader()
            .Build()));
        }
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "api/news",
                    Description = "API v1"

                });
            });
        }
        public static void AddHangfire(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddHangfire(options => options.
            UseSqlServerStorage(configuration.
            GetConnectionString("DefaultConnection")));
        }


        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<WebApiDbContext>(options => options.
            UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }

        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                .AddJwtBearer(option =>
            {
                option.SaveToken = true;
                option.RequireHttpsMetadata = false;
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]))


                };
            });
        }

        public static void ConfigureMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
        }

        public static void ConfigureMediatR(this IServiceCollection services)
        {
            var assembly = AppDomain.CurrentDomain.Load("WebApiCQRS");
            services.AddMediatR(assembly);
            services.AddTransient<IMediator, Mediator>();

        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(op =>
            {
                op.Password.RequireDigit = false;
                op.Password.RequiredLength = 5;
                op.Password.RequireUppercase = false;
                op.Password.RequireNonAlphanumeric = false;

            }).AddEntityFrameworkStores<WebApiDbContext>()
              .AddDefaultTokenProviders();
        }
        public static void AddTarnsientParsers(this IServiceCollection services)
        {
            services.AddTransient<IWebApiParser_Onliner, WebApiParser_Onliner>();
            services.AddTransient<IWebApiParser_S13, WebApiParser_S13>();
            services.AddTransient<IWebApiParser_TutBy, WebApiParser_TutBy>();
            services.AddTransient<IWebApiGeneralParser, WebApiGeneralParser>();

        }
        public static void AddTarnsientNewsRepository(this IServiceCollection services)
        {
            services.AddTransient<IExistNewsInDataBase, ExistNewsInDataBase>();
            services.AddTransient<IAddNewsInDataBase, AddNewsInDataBase>();
        }
        public static void AddTarnsientAnalysisPositivity(this IServiceCollection services)
        {
            services.AddTransient<IConvertJsonAFINNToDictinary, ConvertJsonAFINNToDictinary>();
            services.AddTransient<IGetFromStringToJsonResponsFromApi, GetFromStringToJsonResponsFromApi>();
            services.AddTransient<IDeserializeRespons, DeserializeRespons>();
            services.AddTransient<ILemmatization, Lemmatization>();
            services.AddTransient<INewsAddPositivity, NewsAddPositivity>();
        }
    }
}
