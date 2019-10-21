using Identity.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Identity.InitialRole
{
    //Если лень делать "amin" & "user" руками 
    public class RoleInitializer
    {
        public static async Task InitializeAsync(UserManager<MyUsers> userManager, RoleManager<MyRole> roleManager)
        {
            string adminEmail = "admin@mail.com";
            string userEmail = "user@mail.com";
            string adminpassword = "qwerty";
            string userpassword = "ytrewq";
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new MyRole() { Name = "admin" });
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new MyRole() { Name = "user" });
            }
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                var admin = new MyUsers { Email = adminEmail, UserName = adminEmail };
                var resultAdmin = await userManager.CreateAsync(admin, adminpassword);

                if (resultAdmin.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");

                }
            }
            if(await userManager.FindByNameAsync(userEmail) == null)
            {
                var user = new MyUsers { Email = userEmail, UserName = userEmail };
                var resultUser = await userManager.CreateAsync(user, userpassword);
                if (resultUser.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "user");
                }
            }
        }
    }
}
