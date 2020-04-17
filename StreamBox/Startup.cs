using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StreamBox.Models;
using StreamBox.Repositories;
using StreamBox.Services;

namespace StreamBox
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration Config)
        {
            _config = Config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddControllersWithViews();
            services.AddSession();

            //To make Authorize as a global and make sure the users is authinticated befor log in 
            // services.AddControllersWithViews(config =>
            // {
            //     var policy = new AuthorizationPolicyBuilder()
            //                      .RequireAuthenticatedUser()
            //                      .Build();
            //     config.Filters.Add(new AuthorizeFilter(policy));
            // }).AddXmlSerializerFormatters();

            //Make Debicies to DataBase . 
            services.AddDbContextPool<AppDbContext>(
               e => e.UseSqlServer(_config.GetConnectionString("StreamTecDbConnection")));

            //To make Authorize as a global and make sure the users is authinticated befor log in 
            // services.AddControllersWithViews(config =>
            // {
            //     var policy = new AuthorizationPolicyBuilder()
            //                      .RequireAuthenticatedUser()
            //                      .Build();
            //     config.Filters.Add(new AuthorizeFilter(policy));
            // }).AddXmlSerializerFormatters();

            //Configration formate of password :)))
            // services.Configure<IdentityOptions>(option =>
            // {
            //     option.Password.RequiredLength = 3;
            //     option.Password.RequireUppercase = false;
            //     option.Password.RequireNonAlphanumeric = false;
            //     option.Password.RequireDigit = false;
            // });

            services.AddScoped<IGenericRepository<Stream>, StreamService>();
            services.AddScoped<IGenericRepository<Server>, ServerService>();

            //To put authentication scheme .
            // services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddDefaultTokenProviders()
            //    .AddEntityFrameworkStores<AppDbContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseStatusCodePagesWithRedirects("/Error/{statusCode}");
                app.UseHsts();
            }

            //General Data Protection Regulation (GDPR) regulations ... redirects HTTP requests to HTTPS.
            app.UseHttpsRedirection();

            //For static file "wwwroot"
            app.UseStaticFiles();

      
            app.UseRouting();

            //who are you ?
            //is the process that identify who the user he is ?
            // app.UseAuthentication();

            //are you allowed?
            //what the user can and cannot do ?
            // app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
