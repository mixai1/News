using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using WebApiEntity.ModelsDto;

namespace WebApiNews_site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(IConfiguration config, UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _config = config;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// POST,Register
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Ok(User)</returns>
        [HttpPost]
        [AllowAnonymous]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new IdentityUser
                    {
                        UserName = model.UserName,
                        Email = model.Email
                    };

                    var result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        if (model.UserName == "admin")
                        {
                            if (await _roleManager.FindByNameAsync("admin") == null)
                            {
                                await _roleManager.CreateAsync(new IdentityRole() { Name = "admin" });
                            }
                            await _userManager.AddToRoleAsync(user, "admin");
                        }
                        await _signInManager.SignInAsync(user, false);
                        Log.Information("Action Register => completed successfully");
                        var token = await CreateJWTToken(model.Email, user);
                        var role = await _userManager.GetRolesAsync(user);

                        return Ok(new UserDto
                        {
                            Name = user.UserName,
                            Email = user.Email,
                            Role = role,
                            Token = token
                        });
                    }
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                Log.Error($"Action Register => {ex.Message}");
                return StatusCode(500);
            }
        }

        /// <summary>
        /// POST,Login
        /// </summary>
        /// <param name="model"></param>
        /// <returns>Ok(User)</returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto model)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);

                if (result.Succeeded)
                {
                    var appUser = _userManager.Users.SingleOrDefault(r => r.Email == model.Email);
                    Log.Information("Action Login => completed successfully");
                    var token = await CreateJWTToken(model.Email, appUser);
                    var role = await _userManager.GetRolesAsync(appUser);

                    return Ok(new UserDto
                    {
                        Name = appUser.UserName,
                        Email = appUser.Email,
                        Role = role,
                        Token = token
                    });
                }
            }
            catch (Exception ex)
            {
                Log.Error($"Action Login =>{ex.Message}");
            }

            return StatusCode(500);
        }

        private async Task<object> CreateJWTToken(string email, IdentityUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddMinutes(Convert.ToDouble(_config["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _config["JwtIssuer"],
                _config["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
