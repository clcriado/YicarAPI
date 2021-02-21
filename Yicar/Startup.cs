using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Yicar.BL.Contracts;
using Yicar.BL.Implementations;
using Yicar.DAL.Models;
using Yicar.DAL.Repositories.Contracts;
using Yicar.DAL.Repositories.Implementations;

namespace Yicar
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
            services.AddControllers();

            // Automapper
            services.AddAutoMapper(typeof(MappingProfile));

            // Para habilitar CORS en nuestra API
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

            // Inyección del contexto:
            services.AddDbContext<yicarContext>(opts => opts.UseMySql(Configuration["ConnectionString:YicarDB"]));

            // Procedemos a inyectar dependencias:
            services.AddScoped<ILoginBL, LoginBL>();
            services.AddScoped<ILoginRepository, LoginRepository>();

            services.AddScoped<IVentasBL, VentasBL>();
            services.AddScoped<IVentaRepository, VentaRepository>();

            //Swagger
            AddSwagger(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/S.L./swagger.json", "Foo API V1");
            });//fin Swagger

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }





        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "S.L.";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Yicar {groupName}",
                    Version = groupName,
                    Description = "Yicar API",
                    Contact = new OpenApiContact
                    {
                        Name = "Yicar Company",
                        Email = string.Empty,
                        Url = new Uri("https://foo.com/"),
                    }
                });
            });

        }

     }

}
