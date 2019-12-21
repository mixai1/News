using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiEntity.ModelsDto;

namespace WebApiNews_site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UserController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task< IActionResult> Index()
        {
            return Ok(await _userManager.Users.ToListAsync());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="creatModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateDto creatModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
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
            return Ok(creatModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="editModel"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Edit([FromBody]EditDto editModel)
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
            return Ok(editModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> ChangePassword(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null)
            {
                return NotFound();
            }
            ChangePasswordDto model = new ChangePasswordDto { /*user.Id == Id.ToString(),*/ Email = user.Email };
            return Ok(model);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> ChangePassword([FromBody]ChangePasswordDto model)
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

            return Ok(model);
        }
    }
}