using System.Threading.Tasks;
using Entity.IdetityModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using News_site.Areas.IdentityViewModel;

namespace News_site.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<MyUsers> _userManager;
        private readonly SignInManager<MyUsers> _singInManager;
        private readonly RoleManager<MyRole> _roleManager;


        public AccountController(UserManager<MyUsers> userManager, SignInManager<MyUsers> singInManager,RoleManager<MyRole> roleManager)
        {
            _userManager = userManager;
            _singInManager = singInManager;
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisteredModels registrModel)
        {
            if (ModelState.IsValid)
            {
                var user = new MyUsers()
                {
                    Email = registrModel.Email,
                    UserName = registrModel.UserName,
                    
                };

                var creatUser = await _userManager.CreateAsync(user, registrModel.Password);
                if (creatUser.Succeeded)
                {
                    if (registrModel.UserName == "admin")
                    {
                        if(await _roleManager.FindByNameAsync("admin") == null)
                        {
                            await _roleManager.CreateAsync(new MyRole() { Name = "admin" });
                        }
                        await _userManager.AddToRoleAsync(user, "admin");
                    }
                    await _singInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                    foreach (var i in creatUser.Errors)
                    {
                        ModelState.AddModelError("", i.Description);
                    }
            }

            return View(registrModel);
        }

        [HttpGet]
        public IActionResult Login(string url = null)
        {
            return View(new LoginModel { Url = url});
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _singInManager.
                    PasswordSignInAsync(loginModel.Email, loginModel.Password, loginModel.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(loginModel.Url) && Url.IsLocalUrl(loginModel.Url))
                    {
                        return Redirect(loginModel.Url);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid UserName or Password");
                }

            }

                return View(loginModel);
        }


        [HttpPost]
        public async Task<IActionResult> LogOff()
        {
            await _singInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}