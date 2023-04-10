using Hospital.API.Data;
using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Models.Entities;
using Hospital.API.Models.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Hospital.API.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class ProfileController : Controller
    {
        private readonly HospitalDbContext dbContext;
        private readonly IUser userContext;
        private readonly IPatient patientContext;
        private readonly IHospital hospital;

        public ProfileController(HospitalDbContext dbContext, IUser user, IPatient patient, IHospital hospital)
        {
            this.dbContext = dbContext;
            this.userContext = user;
            this.patientContext = patient;
            this.hospital = hospital;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> getProfile()
        {
            UserProfileModel userProfile = new UserProfileModel();

            User user = userContext.getUserById(Guid.Parse(User.Identity.Name));

            userProfile = new UserProfileModel
            {
                patientId = patientContext.getPatientByUserId(user.id).id,
                surName = user.surname,
                name = user.name,
                middleName = user.middleName,
                age = user.Age,
                gender = dbContext.genderTable.Find(user.genderId).genderName,
                base64StringPhoto = null,
            };

            byte[] arr = dbContext.userPictureTable.FirstOrDefault(x => x.id == user.userPictureId).picture;
            if(arr != null || arr!= default)
            {
                userProfile.base64StringPhoto = Convert.ToBase64String(arr);
            }         
            
            return Ok(userProfile);
        }

        
        [HttpGet("appoiments")]
        [Authorize]
        public ActionResult<List<Appoiment>> getAppoimentsForPatient()
        {
            var patientId = patientContext.getPatientByUserId(Guid.Parse(User.Identity.Name)).id;

            var listOfAppoiments = dbContext.appoimentTable.Where(x=>x.patientId == patientId).ToList();

            List<AppoimentModel> appoiments = new List<AppoimentModel>();

            foreach(var item in listOfAppoiments)
            {
                var userId = userContext.getUserByPatientId(item.patientId);
                item.office = dbContext.officeTable.Find(item.officeId);
                appoiments.Add(new AppoimentModel
                {
                    id = item.id,
                    patientName = $"{dbContext.userTable.Find(userId).surname} " +
                    $"{dbContext.userTable.Find(userId).name} " +
                    $"{dbContext.userTable.Find(userId).middleName}",
                    doctorName = $"{userContext.getUserByDoctorId(item.doctorId).surname}" +
                    $"{userContext.getUserByDoctorId(item.doctorId).name} " +
                    $"{userContext.getUserByDoctorId(item.doctorId).middleName}",
                    indexesOfPatient = dbContext.indexesTable.Find(userId),
                    officeName = item.office.name,
                    officeNumberInHospital = item.office.numberInHospital,
                    officeDesc = item.office.additionalInformation,
                    hospitalName = "Тестується",
                    Date = item.dateTime

                }) ;
            }

            return Json(listOfAppoiments);
        }

        [HttpGet("cases")]
        [Authorize]
        public ActionResult<List<CaseModel>> getCasesForPatient()
        {
            var patientId = patientContext.getPatientByUserId(Guid.Parse(User.Identity.Name)).id;

            var listOfCases = dbContext.caseTable.Where(x => x.patientId == patientId).ToList();

            List<CaseModel> cases = new List<CaseModel>();

            foreach (var item in listOfCases)
            {
                var userId = userContext.getUserByPatientId(item.patientId);

                cases.Add(new CaseModel
                {
                    id = item.id,
                    patientName = $"{dbContext.userTable.Find(userId).surname} " +
                    $"{dbContext.userTable.Find(userId).name} " +
                    $"{dbContext.userTable.Find(userId).middleName}",
                    caseStatus = dbContext.casesStatusTable.Find(item.caseStatusId).statusName,
                    office = dbContext.officeTable.Find(item.officeId),
                    diseaseName = dbContext.diseaseTable.Find(item.diseaseId).name,
                    hospitalName = hospital.getHospitalByCase(item).name,
                    anamnesis = item.anamnesis,
                    treatmentInformation = item.treatmentInformation,
                    createDate = item.createDate

                }) ;
            }
            return Json(cases);
        }
    }
}
