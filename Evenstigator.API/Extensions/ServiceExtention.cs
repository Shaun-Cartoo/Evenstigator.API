using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Evenstigator.API.Extensions
{
    public static class ServiceExtention
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options =>
            {

            });
        }
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            // Register the Swagger Generator service. This service is responsible for genrating Swagger Documents.
            // Note: Add this service at the end after AddMvc() or AddMvcCore().
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Evenstigator API",
                    Version = "v1",
                    Description = "API for Evenstigator windows service that logs events and stores them at custom locations",
                    Contact = new OpenApiContact
                    {
                        Name = "Khathutshelo Matidza",
                        Email = string.Empty,
                        Url = new Uri("http://cartoo.co.za"),
                    },
                });
            });
        }
    }
}
