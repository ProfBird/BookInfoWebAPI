using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BookInfo.Data;
using BookInfo.Models;
using BookInfo.Services;
using System.Runtime.InteropServices;

namespace BookInfo
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
            var os = RuntimeInformation.OSArchitecture;
			if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			{
				services.AddDbContext<ApplicationDbContext>(
					options => options.UseSqlServer(
                        Configuration.GetConnectionString("SqlServerConnection")));
			}
			else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
			{
				services.AddDbContext<ApplicationDbContext>(
				   options => options.UseSqlite(
                            Configuration.GetConnectionString("SQLiteConnectionString")));
			}
			else
			{
				services.AddDbContext<ApplicationDbContext>(
					options => options.UseMySql(
						Configuration.GetConnectionString("MySqlConnection")));
			}

            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
			using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                context.Database.Migrate();   // If db doesn't exist, creates it. Applies any pending migrations
            }

			if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

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
