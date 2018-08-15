﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Snap.Notes.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using StructureMap;
using Snap.Notes.Core.SharedKernel;
using Snap.Notes.Core.Interfaces;

namespace Snap.Notes.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        // Setup shared objects that can be used throughout the application through DI
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    // Access to configuration data via Configuration's key 
                    Configuration["DefaultConnection:ConnectionString"])
            );

            //services.AddDbContext<AppDbContext>(options =>
            //    options.UseSqlServer(
            //        Configuration["Data:SportStoreIdentity:ConnectionString"]
            //        )
            //);
            //services.AddIdentity<IdentityUser, IdentityRole>()
            //    .AddEntityFrameworkStores<AppIdentityDbContext>()
            //    .AddDefaultTokenProviders();

            // Specify the same object should be used to satisfy related requests for Cart instances
            //services.AddScoped<CartService>(sp => SessionCart.GetCart(sp));
            // Specify the same object should always be used
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            // Create new object each time the interface is needed
            // setup the shared objects used in MVC applications
            services.AddMvc();
            // setup in memory data store
            services.AddMemoryCache();
            // register services to access session data
            services.AddSession();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            var container = new Container();

            container.Configure(config =>
            {
                config.Scan(_ =>
                {
                    _.AssemblyContainingType(typeof(Startup)); // Web
                    _.AssemblyContainingType(typeof(BaseEntity)); // Core
                    _.Assembly("Snap.Notes.Infrastructure"); // Infrastructure
                    _.WithDefaultConventions();
                    _.ConnectImplementationsToTypesClosing(typeof(IHandler<>));
                });

                // TODO: Add Registry Classes to eliminate reference to Infrastructure

                // TODO: Move to Infrastucture Registry
                config.For(typeof(IRepository<>)).Add(typeof(EfRepository<>));

                //Populate the container using the service collection
                config.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // Display details of exception during development process. Should be disabled when deploying the app.
                app.UseDeveloperExceptionPage();
                // Add simple message  to HTTP responses e.g. 404 
                app.UseStatusCodePages();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }


            // Enable support for serving static content from wwwroot folder
            app.UseStaticFiles();
            // Use session
            app.UseSession();
            // Setup component that intercept request and response to implement the security policy
            app.UseAuthentication();
            // Enable ASP.NET Core MVC
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                     name: null,
                     template: "{category}/Page{productPage:int}",
                     defaults: new { controller = "Product", action = "List" }
                );

                routes.MapRoute(
                    name: null,
                    template: "Page{productPage:int}",
                    defaults: new { controller = "Product", action = "List", page = 1 }
                );

                routes.MapRoute(
                    name: null,
                    template: "{category}",
                    defaults: new { controller = "Product", action = "List", page = 1 }
                );

                routes.MapRoute(
                    name: null,
                    template: "",
                    defaults: new { controller = "Product", action = "List", page = 1 });

                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");

            });
            //SeedData.EnsurePopulated(app);
            //IdentitySeedData.EnsurePopulated(app);
        }
    }
}
