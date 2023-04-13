using Hospital.API.Data;
using Hospital.API.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Hospital.API.Models.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Hospital.API.Data.DataManager.Interfaces;

namespace Hospital.API.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class AuthController : Controller
    {
        private readonly HospitalDbContext dbContext;
        private readonly HashPassword hashPassword;
        private readonly IUser userContext;
        private readonly IDoctor doctorContext;
        public IConfiguration Configuration { get; }

        public AuthController(HospitalDbContext hospitalDbContext, HashPassword hashPassword, IUser user, IDoctor doctor, IConfiguration conf)
        {
            this.dbContext = hospitalDbContext;
            this.hashPassword = hashPassword;
            this.userContext = user;
            this.doctorContext = doctor;
            this.Configuration = conf;
        }

        [HttpGet]
        public IActionResult RegisterUser()
        {
            LocationView locationView = new LocationView
            {
                regions = dbContext.regionTable.ToList(),
                districts = dbContext.districtTable.ToList(),
                settlements = dbContext.settlementTable.ToList()
            };

            return Json(locationView);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegistrationModel registrationModel)
        {
            Guid userId = Guid.NewGuid();

            if (userContext.addUser(registrationModel, userId))
            {
                var issuer = Configuration["JWT:Issuer"];
                var audience = Configuration["JWT:Audience"];
                var key = Encoding.ASCII.GetBytes(Configuration["JWT:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                {
                    new Claim("Id", Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Name, userId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString())
                }),
                    Expires = DateTime.UtcNow.AddDays(3),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha512Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);

                await dbContext.SaveChangesAsync();
                return Ok(jwtToken);
            }
            else
            {
                if(dbContext.userTable.Any(x=> x.mail == registrationModel.mail))
                {
                    return NotFound("Mail does exist");
                }
                if(dbContext.userTable.Any(x => x.phoneNumber == registrationModel.phoneNumber))
                {
                    return NotFound("Phone number does exist");
                }
                return NotFound();
            }

            
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var searchMail = userContext.getUserByMail(loginModel.mail).mail;

            if(searchMail == default ||
               !hashPassword.Verify(loginModel.password, 
               userContext.getUserByMail(loginModel.mail).passwordHash)) {
                return NotFound();
            }

            var userId = userContext.getUserByMail(loginModel.mail).id;

            var issuer = Configuration["JWT:Issuer"];
            var audience = Configuration["JWT:Audience"];
            var key = Encoding.ASCII.GetBytes(Configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
            {
                    new Claim("Id", Guid.NewGuid().ToString()),
                    new Claim(ClaimTypes.Name, userId.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti,
                    Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(3),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            return Ok(jwtToken);
        }


        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok();
        }

       
    }
}
