using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructuer.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUserAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser()
                {
                    DisplayName = "Admin",
                    Email = "Admin@gmail.com",
                    UserName = "Admin@gmail.com",
                    Address = new Address
                    {
                        FirstName = "izz",
                        LastName = "kalbouneh",
                        Street = "10 th street",
                        City = "New yourk",
                        State = "NY",
                        ZipCode = "962",
                    }
                };
                await userManager.CreateAsync(user, "Admin.123");
            }
        }
    }
}