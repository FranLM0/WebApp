using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CarniceriaWebApp.Controllers;
using CarniceriaWebApp.Data;
using CarniceriaWebApp.Data.Entities;
using CarniceriaWebApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace CarniceriaWebApp
{
    public class Startup
    {

        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddIdentity<StoreUser, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;
            })
        .AddEntityFrameworkStores<CarniceriaContext>();

            services.AddAuthentication()
              .AddCookie()
              .AddJwtBearer(cfg =>
              {
                  cfg.TokenValidationParameters = new TokenValidationParameters()
                  {
                      ValidIssuer = _config["Tokens:Issuer"],
                      ValidAudience = _config["Tokens:Audience"],
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]))
                  };
              });

            services.AddDbContext<CarniceriaContext>();
            services.AddTransient<IMailService, NullMailService>();

            services.AddTransient<CarniceriaSeeder>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ICarniceriaRepository, CarniceriaRepository>();

            services.AddControllersWithViews()
              .AddRazorRuntimeCompilation()
              .AddNewtonsoftJson(cfg => cfg.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddRazorPages();
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }
            
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
      app.UseAuthorization();

            app.UseEndpoints(cfg =>
            {
                cfg.MapControllerRoute("Default",
                    "/{controller}/{action}/{id?}",
                    new { controller = "App", action = "Index"});

                cfg.MapRazorPages();
            });
        }
    }
}
