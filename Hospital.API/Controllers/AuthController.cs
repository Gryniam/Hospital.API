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

namespace Hospital.API.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class AuthController : Controller
    {
        private readonly HospitalDbContext dbContext;
        private readonly HashPassword hashPassword;

        public AuthController(HospitalDbContext hospitalDbContext, HashPassword hashPassword)
        {
            this.dbContext = hospitalDbContext;
            this.hashPassword = hashPassword;
        }

        [ValidateAntiForgeryToken]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromBody] RegistrationModel registrationModel, bool isDoctor)
        {
            User user = new User();
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

            user.id = Guid.NewGuid();
            user.isAdmin = false;
            user.phoneNumber = registrationModel.phoneNumber;
            user.genderId = dbContext.genderTable.FirstOrDefault(
            x => x.genderName == registrationModel.gender).id;

            if(!Regex.IsMatch(registrationModel.mail, emailPattern) || isIdenticalMail(registrationModel.mail))
            {
                return NotFound();
            }

            user.mail = registrationModel.mail;
            user.passwordHash = hashPassword.Hash(registrationModel.password);
            user.userPictureId = Guid.NewGuid();

            await dbContext.userPictureTable.AddAsync(new UserPicture
            {
                id = user.userPictureId,
                picture = null
                //Тут треба буде доробити
            });


            await dbContext.userTable.AddAsync(user);
            //При створенні юзера створюється пацієнт
            await dbContext.patientTable.AddAsync(new Patient
            {
                id = Guid.NewGuid(),
                UserId = user.id
            });

            if (isDoctor)
            {
                await dbContext.doctorTable.AddAsync(new Doctor
                {
                    id = Guid.NewGuid(),
                    userId = user.id,
                    additionalInformation = null,
                });
            }
            await Authenticate(user.id.ToString());
            await dbContext.SaveChangesAsync();
            return Ok();
        }

        private bool isIdenticalMail(string mail)
        {
            if (dbContext.userTable.FirstOrDefault(x => x.mail == mail) != default)
            {
                return true;
            }
            return false;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel loginModel)
        {
            var searchMail = dbContext.userTable.FirstOrDefault(x => x.mail == loginModel.mail).mail;

            if(searchMail == default ||
               !hashPassword.Verify(loginModel.password, 
               dbContext.userTable.FirstOrDefault(x => x.mail == loginModel.mail).passwordHash)) {
                return NotFound();
            }

            var userId = dbContext.userTable.FirstOrDefault(x => x.mail == loginModel.mail).id;

            await Authenticate(userId.ToString());
            return Ok();
        }

        [ValidateAntiForgeryToken]
        [Authorize]
        [HttpPost("logout")]
        public async Task<IActionResult> logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok();
        }


        private async Task Authenticate(string userId)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userId)
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
