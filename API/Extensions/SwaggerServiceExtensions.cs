using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection  AddSwaggerDocumntation(this IServiceCollection services)
         {
        //      services.AddSwaggerGen(c=> 
        //  {
        //          c.SwaggerDoc("v1" , new Microsoft.OpenApi.Models.OpenApiInfo
        //           {Title = "SkiNet API" , Version="v1"});
        //      });
         services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "SkiNet API", Version = "v1" });
        });

             return services;

        }

        public static IApplicationBuilder UseSwaggerDocumention(this IApplicationBuilder app)
        {
            app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c => {c.SwaggerEndpoint("/swagger/v1/swagger.json","SkiNet API v1");});
            return app;

            
        }
    }
}