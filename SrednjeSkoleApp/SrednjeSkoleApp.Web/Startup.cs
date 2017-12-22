﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SrednjeSkoleApp.Data.EF;
using SrednjeSkoleApp.Data.Models;

namespace SrednjeSkoleApp.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
    ***REMOVED***

        public IConfiguration Configuration { get; ***REMOVED***

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MojKontext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("fit-server")));
            services.AddMvc();
    ***REMOVED***

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
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
                    name: "default",
                    template: "{controller=Home***REMOVED***/{action=Index***REMOVED***/{id?***REMOVED***");
        ***REMOVED***);
    ***REMOVED***
***REMOVED***
***REMOVED***