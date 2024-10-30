using AutoMapper;
using C42_G01_MVC_Demo.BLL.Interfaces;
using C42_G01_MVC_Demo.BLL.Repositories;
using C42_G01_MVC_Demo.DAL.Models;
using C42_G01_MVC_Demo.DL.Context;
using C42_G01_MVC01_Demo.PL.Helpers;
using C42_G01_MVC01_Demo.PL.MappingProfiles;
using C42_G01_MVC01_Demo.PL.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace C42_G01_MVC01_Demo.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var Builder = WebApplication.CreateBuilder(args);
			#region Configure Services That Allow Dependency Injection
			Builder.Services.AddControllersWithViews();

			Builder.Services.AddDbContext<MVCProjectDbContext>(
					Options => Options.UseSqlServer(Builder.Configuration.GetConnectionString("DefaultConnection"))
				);

			Builder.Services.Configure<MailSettings>(Builder.Configuration.GetSection("MailerSendSettings"));
			
			Builder.Services.Configure<TwilioSMSSettings>(Builder.Configuration.GetSection("TwilioSMS"));
			
			Builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

			Builder.Services.AddTransient<IMailSetting, MailSetting>();
			Builder.Services.AddTransient<ITwilioSMSSetting, TwilioSMSSetting>();

			Builder.Services.AddAutoMapper(C => C.AddProfiles(new List<Profile>() { new EmployeeProfile(), new UserProfile(), new IdentityRoleProfile() }));
			
			Builder.Services.AddIdentity<ApplicationUser, IdentityRole>(Options =>
			{
				Options.Password.RequireNonAlphanumeric = true;
				Options.Password.RequireDigit = true;
				Options.Password.RequireLowercase = true;
				Options.Password.RequireUppercase = true;
			})
				.AddEntityFrameworkStores<MVCProjectDbContext>()
				.AddDefaultTokenProviders();
			Builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(Options =>
			{
				Options.LoginPath = "/Auth/Login";
				Options.AccessDeniedPath = "/Auth/Login";
				Options.ForwardAuthenticate = "/Auth/Login";
				Options.ForwardSignIn = "/Auth/Login";
			});
			Builder.Services.Configure<SecurityStampValidatorOptions>(options =>
			{
				// enables immediate logout, after updating the user's stat.
				options.ValidationInterval = TimeSpan.Zero;
			});
			#endregion
			var app = Builder.Build();
			#region Configure HTTP Request Pipelines - Middelwears
			if (app.Environment.IsDevelopment())
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
			#endregion
			app.Run();
		}
    }
}
