

using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync (UserManager<AppUser> userManager) {

                if (!userManager.Users.Any()) {
                    var user = new AppUser
                    {
                        DisplayName = "Bob",
                        Email = "Bob@email.com",
                        UserName = "Bob@email.com",
                        Address = new Address
                        {
                            FirstName = "Bob",
                            LastName = "Bobbity",
                            Street = "10 The street",
                            City = "The city",
                            State = "The state",
                            ZipCode = "12345"
                        }
                    };

                    await userManager.CreateAsync(user, "Pa$$w0rd");
                }
            }
    }
}