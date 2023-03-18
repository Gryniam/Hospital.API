using Hospital.API.Data;
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
        private HospitalDbContext dbContext;

        public ProfileController(HospitalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> getProfile()
        {
            UserProfileModel userProfile = new UserProfileModel();

            User user = dbContext.userTable.Find(Guid.Parse(User.Identity.Name));

            userProfile = new UserProfileModel
            {
                patientId = dbContext.patientTable.First(x => x.UserId == user.id).id,
                surName = user.surname,
                name = user.name,
                middleName = user.middleName,
                age = user.Age,
                gender = dbContext.genderTable.Find(user.genderId).genderName,
                base64StringPhoto = null,
                patientProfile = new PatientProfile()
            };

            userProfile.patientProfile.appoiments = dbContext.appoimentTable.Where(
                    x => x.patientId == userProfile.patientId).ToList();
            userProfile.patientProfile.cases = dbContext.caseTable.Where(
                    x => x.patientId == userProfile.patientId).ToList();

            byte[] arr = dbContext.userPictureTable.FirstOrDefault(x => x.id == user.userPictureId).picture;
            if(arr != null || arr!= default)
            {
                userProfile.base64StringPhoto = Convert.ToBase64String(arr);
            }

            fillAppoimentList(userProfile.patientProfile.appoiments);
            fillCaseList(userProfile.patientProfile.cases);


            var a = dbContext.doctorTable.FirstOrDefault();
            Guid? doctorId = dbContext.doctorTable.FirstOrDefault(x => x.userId == user.id).id;

            if(doctorId != default || doctorId != null)
            {
                userProfile.doctorProfile = new DoctorProfile { 
                    appoimentsToMe = dbContext.appoimentTable.Where(
                    x => x.doctorId == doctorId).ToList(),
                    casesToMe = dbContext.caseTable.Where(
                    x => x.doctorId == doctorId).ToList(),
                    doctorJobs = dbContext.workTable.Where(
                    x => x.doctorId == doctorId).ToList()
                };
                fillAppoimentList(userProfile.doctorProfile.appoimentsToMe);
                fillCaseList(userProfile.doctorProfile.casesToMe);

            }          
            
            return Ok(userProfile);
        }

        private void fillAppoimentList(List<Appoiment> list)
        {
            foreach (var appoiment in list)
            {
                appoiment.patient = dbContext.patientTable.Find(appoiment.patientId);
                appoiment.doctor = dbContext.doctorTable.Find(appoiment.doctorId);
                appoiment.timeOnly = TimeOnly.Parse(dbContext.timeTable.Find(appoiment.timeId).time);
                appoiment.office = dbContext.officeTable.Find(appoiment.officeId);
            }
        }
        private void fillCaseList(List<Case> list)
        {
            foreach (var Case in list)
            {
                Case.patient = dbContext.patientTable.Find(Case.patientId);
                Case.doctor = dbContext.doctorTable.Find(Case.doctorId);
                Case.disease = dbContext.diseaseTable.Find(Case.diseaseId);
                Case.caseStatus = dbContext.casesStatusTable.Find(Case.caseStatusId);
                Case.treatment = dbContext.treatmentTable.Where(x => x.caseId == Case.id).ToList();
            }
        }

    }
}
