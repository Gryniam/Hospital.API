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

        public AuthController(HospitalDbContext hospitalDbContext, HashPassword hashPassword, IUser user, IDoctor doctor)
        {
            this.dbContext = hospitalDbContext;
            this.hashPassword = hashPassword;
            this.userContext = user;
            this.doctorContext = doctor;
        }

        [HttpGet("register")]
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

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegistrationModel registrationModel, bool isDoctor)
        {
            Guid userId = Guid.NewGuid();
            
            if(userContext.addUser(registrationModel, userId))
            {
                if(isDoctor)
                {
                    doctorContext.addDoctor(userId);

                }
                await Authenticate(userId.ToString());
                await dbContext.SaveChangesAsync();
                return Ok();
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

            await Authenticate(userId.ToString());
            return Ok();
        }


        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok();
        }


        private async Task Authenticate(string userId)
        {
            Claim claim;
            if (doctorContext.isDoctorExist(Guid.Parse(userId)))
            {
                claim = new Claim(ClaimsIdentity.DefaultRoleClaimType, "Doctor");
            }
            else
            {
                claim = new Claim(ClaimsIdentity.DefaultRoleClaimType, "Patient");
            }


            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userId),
                claim
            };

            ClaimsIdentity id = 
                new ClaimsIdentity(
                    claims, "HospitalAuthCoockie", 
                    ClaimsIdentity.DefaultNameClaimType, 
                    ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(new ClaimsPrincipal(id));
        }

    }
}
