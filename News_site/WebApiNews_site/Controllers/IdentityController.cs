using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApiCQRS.Commands.UsersCommands;
using WebApiCQRS.Querys.UsersQuerys;

namespace WebApiNews_site.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IMediator _mediator;
        public IdentityController(IConfiguration config, IMediator mediator)
        {
            _config = config;
            _mediator = mediator;
        }

        
        [HttpGet]
        public IActionResult Do()
        {
            return Ok("Method Do");
        }

        /// <summary>
        /// Post api/token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("/token")]
        public async Task<IActionResult> CreatToken([FromBody]CreateUser model)
        {
            var identity = await Authenticate(model.Email, model.Password);
            if (identity == null)
            {
                return Unauthorized();
            }

            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: _config["JwtSettings:Issuer"],
                    audience: _config["JwtSettings:Issuer"],
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.AddMinutes(30),
                    signingCredentials: new SigningCredentials(
                       new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:Key"])),
                    SecurityAlgorithms.HmacSha256)); 
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Ok(response);
        }


        [AllowAnonymous]
        [Route("/register")] 
        [HttpPost]
        public async Task<IActionResult> Registr([FromBody]CreateUser user)
        {
            var result = await _mediator.Send(user);
            if (result)
            {
                return StatusCode(201);
            }
            else
            {
                return BadRequest();
            }
        }

        private async Task<ClaimsIdentity> Authenticate( string userName, string password)
        {
            ClaimsIdentity identity = null;
            var userExist = new DoesExistUser(userName);
            var user = await _mediator.Send(userExist);  
            if (user != null)
            {
                var sha256 = new SHA256Managed();
                var passwordHash = Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
                if (passwordHash == user.Password)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("D")),
                    };
                    identity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, 
                        ClaimsIdentity.DefaultRoleClaimType);
                }
            }
            return identity;


        }

    }
}