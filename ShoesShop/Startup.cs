using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShoesShop.Interfaces;
using ShoesShop.Moq;
using Microsoft.EntityFrameworkCore;
using ShoesShop.Repository;
using ShoesShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace ShoesShop
{
    public class Startup
    {
        private readonly IConfigurationRoot ConfigurationString;
        

        public Startup(IWebHostEnvironment hostEnvironment, IConfiguration configuration)
        {
            ConfigurationString = new ConfigurationBuilder().SetBasePath(hostEnvironment.ContentRootPath).AddJsonFile("DbSettings.json").Build();

            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataBaseContent>(options => options.UseSqlServer(ConfigurationString.GetConnectionString("DefaultConnection")));
            services.AddTransient<IAllShoes, ShoesRepository>();
            services.AddTransient<IAllOrders, OrdersRepository>();
            services.AddTransient<IShoesCategory, CategoryRepository>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopBasket.GetBasket(sp));
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
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

            app.UseStatusCodePages();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "categoryFilter",
                    pattern: "Shoes/{action}/{category?}",
                    defaults: new { controller = "Shoes", action = "ListOfItems" }
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
            });

            using (var area = app.ApplicationServices.CreateScope())
            {
                DataBaseContent content = area.ServiceProvider.GetRequiredService<DataBaseContent>();
                DBObjects.Initial(content);
            }

        }
    }
}
