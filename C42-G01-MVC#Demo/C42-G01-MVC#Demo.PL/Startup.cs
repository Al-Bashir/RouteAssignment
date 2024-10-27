using C42_G01_MVC_Demo.BLL.Repositories;
using C42_G01_MVC_Demo.BLL.Interfaces;
using C42_G01_MVC_Demo.DL.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C42_G01_MVC01_Demo.PL.MappingProfiles;
using Microsoft.AspNetCore.Identity;
using C42_G01_MVC_Demo.DAL.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using AutoMapper;

namespace C42_G01_MVC01_Demo.PL
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<MVCProjectDbContext>(
                    Options => Options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                );
            services.AddAutoMapper(C => C.AddProfiles(new List<Profile>() { new EmployeeProfile(), new UserProfile(), new IdentityRoleProfile() }));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddIdentity<ApplicationUser, IdentityRole>(Options =>
            {
                Options.Password.RequireNonAlphanumeric = true;
                Options.Password.RequireDigit = true;
                Options.Password.RequireLowercase = true;
                Options.Password.RequireUppercase = true;
                })
                .AddEntityFrameworkStores<MVCProjectDbContext>()
                .AddDefaultTokenProviders();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(Options => 
            {
                Options.LoginPath = "/Auth/Login";
                Options.AccessDeniedPath = "/Auth/Login";
                Options.ForwardAuthenticate = "/Auth/Login";
                Options.ForwardSignIn = "/Auth/Login";
            });
            services.Configure<SecurityStampValidatorOptions>(options =>
            {
                // enables immediate logout, after updating the user's stat.
                options.ValidationInterval = TimeSpan.Zero;
            });
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default", 
                    pattern: "{controller=Auth}/{action=Login}/{id?}");
            });
        }
    }
}
