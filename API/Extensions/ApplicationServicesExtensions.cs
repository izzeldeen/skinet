using System.Linq;
using API.Errors;
using Core.Interfaces;
using Infrastructuer.Data;
using Infrastructuer.Data.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBasketRepository , BasketRepository>();
            services.AddScoped(typeof(IGenericRepository<>), (typeof(GenricRepository<>)));


            services.Configure<ApiBehaviorOptions>(options =>
              {
                  options.InvalidModelStateResponseFactory = actionContext =>
                  {
                      var errors = actionContext.ModelState
                      .Where(e => e.Value.Errors.Count > 0)
                      .SelectMany(x => x.Value.Errors)
                      .Select(x => x.ErrorMessage).ToArray();

                      var errorResponse = new ApiValidationErrorResponse
                      {
                          Errors = errors

                      };
                      return new BadRequestObjectResult(errorResponse);
                  };
              });


            return services;


        }
    }
}