using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SrednjeSkoleApp.Data.EF;
using SrednjeSkoleApp.Data.Models;

namespace SrednjeSkoleApp.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName***REMOVED***.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
    ***REMOVED***

        public IConfiguration Configuration { get; ***REMOVED***

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<MojKontext>(options =>
            //    options.UseSqlServer(Configuration.GetConnectionString("lokalni")));
            services.AddMvc();
    ***REMOVED***

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
           

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
        ***REMOVED***
            else
            {
                app.UseExceptionHandler("/Home/Error");
        ***REMOVED***

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists***REMOVED***/{controller=Home***REMOVED***/{action=Index***REMOVED***/{id?***REMOVED***"
                );

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home***REMOVED***/{action=Index***REMOVED***/{id?***REMOVED***");
        ***REMOVED***);
    ***REMOVED***
***REMOVED***
***REMOVED***
