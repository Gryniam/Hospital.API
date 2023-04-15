using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Data;
using Hospital.API.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Hospital.API.Models.Entities;
using System;

namespace Hospital.API.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class EditProfileController : Controller
    {
        private readonly HospitalDbContext dbContext;
        private readonly IUser userContext;
        private readonly ICast castContext;
       

        public EditProfileController(HospitalDbContext dbContext, IUser user, ICast castContext)
        {
            this.dbContext = dbContext;
            this.userContext = user;
            this.castContext = castContext;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> getProfile()
        {
            EditProfileModel profileModel;
            User user = userContext.getUserById(Guid.Parse(User.Identity.Name));

            profileModel = castContext.toEditProfileModel(user);



            return Ok(profileModel);
        }
    }
}
