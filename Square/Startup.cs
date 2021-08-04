using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Square.Database;
using Square.Repositories.List;
using Square.Repositories.Point;
using Square.Services.File;
using Square.Services.List;
using Square.Services.Point;

namespace Square
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
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllRequests", builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            });

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                //Ignore reference looping
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            });

            services.AddSwaggerGen();

            services.AddDbContext<ApplicationDatabaseContext>(options =>
            {
                string connectionString = Configuration.GetConnectionString("SquareDatabase");
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString),
                (settings) =>
                {
                    settings.EnableRetryOnFailure();
                });
            }
            );

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<IPointRepository, PointRepository>();
            services.AddScoped<IListRepository, ListRepository>();

            services.AddScoped<IPointService, PointService>();
            services.AddScoped<IListService, ListService>();

            services.AddScoped<IFileService, FileService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("AllowAllRequests");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(options => { options.SwaggerEndpoint("/swagger/v1/swagger.json", ""); });
        }
    }
}
