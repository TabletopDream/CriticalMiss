using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CriticalMiss.UI.Extensions;
using CriticalMiss.UI.Repository;
using CriticalMiss.UI.Repository.Interfaces;
using CriticalMiss.UI.Services.HTTP;
using CriticalMiss.UI.Services.HTTP.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace CriticalMiss.UI
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
            services.AddMvc();
            
            //services.AddDbContext<CriticalMissDbContext>(optionsBuilder =>
            //{
            //    var conn = Configuration.GetConnectionString("CriticalMissDB");

            //    optionsBuilder.UseSqlServer(conn);
            //});
            // Configuration options
            services.Configure<HttpServicesConfiguration>(Configuration.GetSection(HttpServicesConfiguration.ConfigurationKey));

            // Repositories
            services.AddTransient<IGameBoardRepository, GameBoardRepository>();
            services.AddSingleton<ILibraryHttpClientProvider, LibraryHttpClientProvider>();

            // JSON Model Injections

            // Add JSON Injector Meta Handler
            services.AddSingleton<IDIMeta>(s =>
            {
                return new DIMetaDefault(services);
            });

            services.AddTransient<IConfigureOptions<MvcJsonOptions>, JsonOptionsSetup>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
