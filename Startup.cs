using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using authentication_repo.Data;
using authentication_repo.Models;
using Microsoft.AspNetCore.Identity;

namespace TheBookCave
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
            // Geymd i conflig skra
            services.AddDbContext<AuthenticationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("AuthenticationConnection")));
            // User sem er tengdur vid inskradan notanda
            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<AuthenticationDbContext>()
                    .AddDefaultTokenProviders();

            // breyta akvednum hlutum vid audkenninguna :
            services.Configure<IdentityOptions>(config => {
                config.User.RequireUniqueEmail = true;

                config.Password.RequiredLength = 8;
            });

            
            services.ConfigureApplicationCookie(options => {
                options.Cookie.HttpOnly = true;
                // kakan lifir i 3 tima
                options.ExpireTimeSpan = TimeSpan.FromHours(3);
                //rederictad a tedda ef notnadi er ekki innskradur
                options.LoginPath = "/Account/Login";
                // vidkomandi fer ef hann hefur ekki adgang
                options.AccessDeniedPath = "/Account/AceessDenied";
                options.SlidingExpiration = true;
            });

            services.AddMvc();
        }

        // This method get s called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                
            }
            else
            {
                app.UseExceptionHandler("/FrontPage/Error");
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=FrontPage}/{action=Index}/{id?}");
            });
        }
    }
}
