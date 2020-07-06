using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Extensions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerExtensions(this IServiceCollection services) {
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo() {Title = "ECommApp.API", Version = "v2"});
            });

            return services;
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app) {
            app.UseSwagger();
            
            app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "ECommAppAPI v1"));

            return app;
        }
    }
}