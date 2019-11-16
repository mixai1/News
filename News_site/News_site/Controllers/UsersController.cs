using Entity.IdetityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using News_site.Areas.IdentityViewModel;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace News_site.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly UserManager<MyUsers> _userManager;
        public UsersController(UserManager<MyUsers> userManager)
        {
            _userManager = userManager;
        }


        [HttpGet]
        public IActionResult Index()
        {
            return View(_userManager.Users.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateModel creatModel)
        {
            if (ModelState.IsValid)
            {
                var user = new MyUsers()
                {
                    Email = creatModel.Email,
                    UserName = creatModel.UserName
                };
                var result = await _userManager.CreateAsync(user, creatModel.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Users");
                }
                else
                {
                    foreach (var i in result.Errors)
                    {
                        ModelState.AddModelError("", i.Description);
                    }
                }
            }
            return View(creatModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {

            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user != null)
            {
                var result = new EditModel()
                {
                    Email = user.Email,
                    UserName = user.UserName,
                    Id = user.Id
                };
                return View(result);
            }
            else
            {
                return NotFound("User not Found");
            }

        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditModel editModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(editModel.Id.ToString());
                if (user != null)
                {
                    user.Email = editModel.Email;
                    user.UserName = editModel.UserName;

                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Users");
                    }
                    else
                    {
                        return BadRequest("Error");
                    }
                }


            }
            return View(editModel);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index", "Users");
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return NotFound();
            }
            ChangePasswordModel model = new ChangePasswordModel { Id = user.Id, Email = user.Email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel model)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.Id.ToString());
                if (user != null)
                {
                    var result =
                        await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }

            }
            else
            {
                ModelState.AddModelError(string.Empty, "User Not Found");
            }

            return View(model);
        }
    }
}
