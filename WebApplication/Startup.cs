using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoMapper;
using WebApplication.Models;
using DataAccessLayer.Entities;

namespace WebApplication
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            /*if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }*/
            app.UseStaticFiles();

            app.UseMvc(/*routes =>
            {
                //routes.MapRoute("default", "{controller=Employees}/{action=All}");
                //routes.MapRoute("default", "{controller}/{action}");
            }*/);

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("404 Not Found");
            });

            AutoMapperConfigure();
        }

        private void AutoMapperConfigure() {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<EmployeeModel, Employee>();
                cfg.CreateMap<Employee, EmployeeModel>();
                cfg.CreateMap<ProductModel, Product>();
                cfg.CreateMap<Product, ProductModel>();
                cfg.CreateMap<OrderModel, Order>();
                cfg.CreateMap<Order, OrderModel>();
                cfg.CreateMap<IndicationModel, Indication>();
                cfg.CreateMap<Indication, IndicationModel>();
                cfg.CreateMap<DeviceModel, Device>();
                cfg.CreateMap<Device, DeviceModel>();
            });
        }
    }
}
