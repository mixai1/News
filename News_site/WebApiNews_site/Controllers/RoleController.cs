using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace WebApiNews_site.Controllers
{
    [ApiController]
    [Authorize(Roles = "admin")]
    [Route("api/[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<IdentityUser> _userManager;
        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Ok(listRole)</returns>
        [HttpGet]
        [Route("listRole")]
        public async Task< IActionResult> Index()
        {
            try
            {
                return Ok( await _roleManager.Roles.ToListAsync());
            }
            catch (Exception ex)
            {

               Log.Error($"{ex.Message}");
            }
            return NotFound();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("createrole")]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                var result = await _roleManager.CreateAsync(new IdentityRole() { Name = name });
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
            return Ok(name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>RedirectToAction("Index", "Role")</returns>
        [HttpPost]
        [Route("deleterole")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var role = await _roleManager.FindByIdAsync(id.ToString());
                if (role != null)
                {
                    var result = await _roleManager.DeleteAsync(role);
                }
                Log.Information("");
                return RedirectToAction("Index", "Role");
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}");
            }

            return NotFound();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Ok(userlist)</returns>
        [HttpGet]
        [Route("listusers")]
        public async Task<IActionResult> UserList()
        {
            try
            {
                Log.Information("");
                return Ok(await _userManager.Users.ToListAsync());
            }
            catch (Exception ex)
            {
                Log.Error($"{ex.Message}");
            }
            return StatusCode(500);
        }


        /// <summary>
        /// api/role/edituser
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roles"></param>
        /// <returns>RedirectToAction("UserList")</returns>
        [HttpPost]
        [Route("edituser")]
        public async Task<IActionResult> Edit(string userId, List<string> roles)
        {
            try
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

                    Log.Information("");

                    return RedirectToAction("UserList");
                }
            }
            catch (Exception ex)
            {

                Log.Error($"{ex.Message}");
            }

            return NotFound();
        }
    }
}