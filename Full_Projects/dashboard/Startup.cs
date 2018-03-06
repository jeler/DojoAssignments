using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using user_dashboard.Models;

namespace user_dashboard {
    public class Startup {
        public IConfiguration Configuration { get; private set; }
        public Startup (IHostingEnvironment env) {
            var builder = new ConfigurationBuilder ()
                .SetBasePath (env.ContentRootPath)
                .AddJsonFile ("appsettings.json", optional : true, reloadOnChange : true)
                .AddEnvironmentVariables ();
            Configuration = builder.Build ();
        }

        public void ConfigureServices (IServiceCollection services) {
            // Add framework services.
            services.AddDbContext<user_dashboardContext> (options => options.UseNpgsql (Configuration["DBInfo:ConnectionString"]));
            services.AddMvc ();
            services.AddSession ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, ILoggerFactory loggerFactory) {
            loggerFactory.AddConsole ();
            app.UseDeveloperExceptionPage ();
            app.UseStaticFiles ();
            app.UseSession ();
            app.UseMvc ();
        }
    }
}