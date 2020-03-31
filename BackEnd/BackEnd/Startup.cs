using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using BackEnd.Interfaces;
using BackEnd.Repositories;
using Microsoft.AspNetCore.Mvc.Cors.Internal;

namespace BackEnd
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
            services.AddDbContext<DBContext>(x => x.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IOngs, OngsRepository>();
            services.AddScoped<IIncidents, IncidentsRepository>();
			
			services.AddCors(setup => {
  setup.AddPolicy("CorsPolicy", builder => {
   builder.AllowAnyHeader();
   builder.AllowAnyMethod();
   builder.WithOrigins("http://localhost:3000");
  });
 });

 services.Configure < MvcOptions > (options => {
  options.Filters.Add(new CorsAuthorizationFilterFactory("CorsPolicy"));
 });
			
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
