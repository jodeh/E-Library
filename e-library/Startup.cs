using e_library.Data;
using e_library.Models;
using e_library.Models.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_library
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
            services.AddMvc(services => services.EnableEndpointRouting = false);

            services.AddScoped<IRepository<Specialist>, SpecialestRepository>();
            services.AddScoped<IRepository<Subject>, SubjectRepository>();
            services.AddScoped<IRepository<SubjectFiles>, SubjectFilesRepository>();
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
            services.AddDbContext<AppDbContext>(x =>
            {

                x.UseSqlServer(Configuration.GetConnectionString("SqlCon"));

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseMvc();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(app =>
            {

                app.MapControllerRoute(
                        name: "areas",
                        pattern: "{area:exists}/{controller=Account}/{action=Login}/{id?}"
                        );

                app.MapControllerRoute(
                        name: "default",
                        pattern: "{controller=Home}/{action=Index}/{id?}"
                        );

            });
        }
    }
}

