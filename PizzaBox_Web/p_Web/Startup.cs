using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Domain.Models;
using Storing.Repositories;
using Domain.Interfaces;

//TO DO: Check this.
using Microsoft.EntityFrameworkCore;

namespace p_Web
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
            string connectionString = Configuration.GetConnectionString("PizzaWebDB");

            services.AddDbContext<PizzaDBContext>(options => options.UseSqlServer(connectionString));

            services.AddTransient<IRepository<Domain.Models.Stores>, RepositoryStore>();
            services.AddTransient<IRepository<Domain.Models.Users>, RepositoryUser>();
            services.AddTransient<IRepository<Domain.Models.Orders>, RepositoryOrder>();
            services.AddTransient<IRepository<Domain.Models.Pizzas>, RepositoryPizza>();
            services.AddTransient<IRepository<Domain.Models.Toppings>, RepositoryToppings>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
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
