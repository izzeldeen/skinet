using Core.Entities.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Infrastructuer.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace API.Extensions
{
    public static class IdentityServiceExtension
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection service, 
                                                              IConfiguration config)
        {
            var bulider = service.AddIdentityCore<AppUser>();
            bulider = new IdentityBuilder(bulider.UserType , bulider.Services);
            bulider.AddEntityFrameworkStores<AppIdentityDbContext>();
            bulider.AddSignInManager<SignInManager<AppUser>>();
            service.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options => 
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                 ValidateIssuerSigningKey = true,
                 IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Token:Key"])),
                 ValidIssuer = config["Token:Issuer"],
                 ValidateIssuer = true,
                 ValidateAudience = false   
                };
                
            });


            return service;
        }
        
    }
}