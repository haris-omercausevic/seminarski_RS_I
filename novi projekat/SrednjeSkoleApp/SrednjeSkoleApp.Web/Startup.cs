﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SrednjeSkoleApp.Data.EF;

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
            services.AddDbContext<MyContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("lokalni")));
            services.AddMvc();
    ***REMOVED***

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
        ***REMOVED***
            else
            {
                app.UseExceptionHandler("/Home/Error");
        ***REMOVED***

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists***REMOVED***/{controller=Home***REMOVED***/{action=Index***REMOVED***/{id?***REMOVED***"
                );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home***REMOVED***/{action=Index***REMOVED***/{id?***REMOVED***");
        ***REMOVED***);
    ***REMOVED***
***REMOVED***
***REMOVED***
