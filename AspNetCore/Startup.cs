using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore
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
            //configuration files from appsettings.json
            Configuration.Bind("Project", new Config());

            //Add dependencies
            services.AddTransient<ICarRepository, EFCarsRepository>();

            //Add database context
            services.AddDbContext<AppDbContextMySql>(x => x.UseMySQL(Config.ConnectionString));

            services.AddControllers();

            services.AddCors(options =>
{
    options.AddPolicy("VueCorsPolicy", builder =>
      {
          builder
          .AllowAnyHeader()
          .AllowAnyMethod()
          .AllowCredentials()
          .WithOrigins("http://localhost:8081");
      });
});
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AspNetCore", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContextMySql dbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            dbContext.Database.EnsureCreated();

            app.UseCors("VueCorsPolicy");

            app.UseRouting();

            app.UseEndpoints(endpoints =>
           {
               endpoints.MapControllers();
           });
        }
    }
}
