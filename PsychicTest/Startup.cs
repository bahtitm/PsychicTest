using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PsychicTest.Entities;
using PsychicTest.Servicies;

namespace PsychicTest
{
    public class Startup
    {
        const int PsychicCount = 2;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
           

            List<string> psychicsNames = new List<string>();
            for (int i = 0; i < PsychicCount; i++)
            {
                var name = $"mag{i}";
                psychicsNames.Add(name);
            }
            GameSession.GameSessionInit(psychicsNames);
        }

        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddSession();
            services.AddHttpContextAccessor();
            services.AddScoped<IApplicationService, ApplicationService>();

        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseSession();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

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
