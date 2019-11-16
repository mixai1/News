using Entity.IdetityModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using News_site.Areas.IdentityViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace News_site.Controllers
{
    [Authorize(Roles ="admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<MyRole> _roleManager;
        private readonly UserManager<MyUsers> _userManager;
        public RoleController(RoleManager<MyRole> roleManager, UserManager<MyUsers> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_roleManager.Roles.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var result = await _roleManager.CreateAsync(new MyRole() { Name = name });
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Role");

                }
                else
                {
                    foreach (var i in result.Errors)
                    {
                        ModelState.AddModelError("", i.Description);
                    }
                }
            }
            return View(name);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index", "Role");
        }


        [HttpGet]
        public IActionResult UserList()
        {
            return View(_userManager.Users.ToList());
        }


        [HttpGet]
        public async Task<IActionResult> Edit(string userId)
        {

            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {

                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleModel model = new ChangeRoleModel
                {
                    UserId = user.Id,
                    UserEmail = user.Email,
                    UserRole = userRoles,
                    AllRole = allRoles
                };
                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {

                var userRoles = await _userManager.GetRolesAsync(user);

                var allRoles = _roleManager.Roles.ToList();

                var addedRoles = roles.Except(userRoles);

                var removedRoles = userRoles.Except(roles);

                await _userManager.AddToRolesAsync(user, addedRoles);

                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToAction("UserList");
            }

            return NotFound();
        }
    }
}
