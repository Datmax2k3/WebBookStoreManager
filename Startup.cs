using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebBookStoreManage.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebBookStoreManage.Controllers;
using WebBookStoreManage.Configuration;
using WebBookStoreManage.Services;
using WebBookStoreManage.Models.Momo;

namespace WebBookStoreManage
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
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
                options.SlidingExpiration = true;
                options.LoginPath = "/Accounts/Login";
                options.LogoutPath = "/Accounts/Logout";
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddControllersWithViews();

            services.AddDbContext<WebBookStoreManageContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("WebBookStoreManageContext"),
                    sqlOptions => sqlOptions.CommandTimeout(120)));

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add<EmployeeCheckFilter>();
            });

            // Configure SmtpSettings
            services.Configure<SmtpSettings>(Configuration.GetSection("SmtpSettings"));
            services.AddSingleton<SmtpSettings>(Configuration.GetSection("SmtpSettings").Get<SmtpSettings>());

            // Register EmailService
            services.AddTransient<EmailService>();
            services.AddLogging();

            /// Cấu hình MoMo API
            services.Configure<MomoOptionModel>(Configuration.GetSection("MomoAPI"));
            services.AddScoped<IMomoService, MomoService>();

            // Đăng ký HttpClient
            services.AddHttpClient();

            services.AddMemoryCache();
            // Đăng ký PasswordService
            services.AddScoped<WebBookStoreManage.PasswordService.PasswordService>();
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
            /*app.UseHttpsRedirection();*/
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
