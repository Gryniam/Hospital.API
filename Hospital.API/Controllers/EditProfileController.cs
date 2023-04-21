﻿using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Data;
using Hospital.API.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Hospital.API.Models.Entities;
using System;
using System.Linq;

namespace Hospital.API.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class EditProfileController : Controller
    {
        private readonly HospitalDbContext dbContext;
        private readonly IUser userContext;
        private readonly ICast castContext;
        private readonly IIndexes indexesContext;
       

        public EditProfileController(HospitalDbContext dbContext, IUser user, ICast castContext, IIndexes indexes)
        {
            this.dbContext = dbContext;
            this.userContext = user;
            this.castContext = castContext;
            this.indexesContext = indexes;
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

        [HttpPost("/updateUserData")]
        [Authorize]
        public async Task<IActionResult> updateUserData([FromBody] RegistrationModel regModel)
        {

            var user = userContext.getUserById(Guid.Parse(User.Identity.Name));

            user.name = regModel.name;
            user.surname = regModel.surname;
            user.middleName = regModel.middleName;

            if (dbContext.userTable.Any(x => x.mail == regModel.mail) && user.mail != regModel.mail)
            {
                return NotFound("Користувач з такою поштою уже існує");
            }

            user.mail = regModel.mail;
            user.birthDate = DateTime.Parse(regModel.birthDate);
            user.Age = DateTime.Now.Year - user.birthDate.Year;
            user.phoneNumber = regModel.phoneNumber;
            user.gender = dbContext.genderTable.FirstOrDefault(x => x.genderName == regModel.name);

            dbContext.userTable.Update(user);
            dbContext.SaveChanges();

            return Ok();
        }

        [HttpPost("/updatePassword")]
        [Authorize]
        public async Task<IActionResult> updateUserPassword([FromBody] ChangePasswordModel model)
        {
            HashPassword hashPassword = new HashPassword();
            var user = userContext.getUserById(Guid.Parse(User.Identity.Name));

            if (!hashPassword.Verify(model.OldPassword,
               user.passwordHash))
            {
                return NotFound("Старий пароль не є вірним");
            }
            else
            {
                user.passwordHash = hashPassword.Hash(model.NewPassword);
                dbContext.userTable.Update(user);
                dbContext.SaveChanges();
            }

            return Ok();
        }

        [HttpPost("/updateIndexes")]
        [Authorize]
        public async Task<IActionResult> updateIndexes([FromBody] IndexesModel indexesModel)
        {
            var indexesOfUser = indexesContext.getIndexesOfUser(Guid.Parse(User.Identity.Name));
            if (indexesOfUser == default)
            {
                indexesContext.addIndexesToUser(Guid.Parse(User.Identity.Name));

                var currentIndexes = indexesContext.getIndexesOfUser(Guid.Parse(User.Identity.Name));
                Indexes indexesToChange = castContext.fromIndexesModel(indexesModel);
                indexesToChange.id = currentIndexes.id;
                indexesToChange.patiendId = currentIndexes.patiendId;

                indexesContext.updateIndexesOfUser(indexesToChange, Guid.Parse(User.Identity.Name));
            }
            else
            {
                Indexes indexesToChange = castContext.fromIndexesModel(indexesModel);
                indexesToChange.id = indexesOfUser.id;
                indexesToChange.patiendId = indexesOfUser.patiendId;
                indexesContext.updateIndexesOfUser(indexesToChange, Guid.Parse(User.Identity.Name));
            }

            return Ok();
        }

        [HttpPost("/updateLocation")]
        [Authorize]
        public async Task<IActionResult> updateLocation([FromBody] RegistrationModel regModel)
        {
            if(dbContext.settlementTable.Any(x=>x.name == regModel.settlementName))
            {
                var a = dbContext.settlementTable.Where(x=>x.name == regModel.settlementName).FirstOrDefault();
                var user = userContext.getUserById(Guid.Parse(User.Identity.Name));
                if (a.id != user.settlementId)
                {
                    user.settlementId = a.id;
                    dbContext.userTable.Update(user);
                    return Ok();
                }
                return NotFound();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
