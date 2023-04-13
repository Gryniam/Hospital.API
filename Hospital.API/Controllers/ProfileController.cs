using Hospital.API.Data;
using Hospital.API.Data.DataManager.EntityFrameworkCore;
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
        private readonly IHospital hospitalContext;
        private readonly IDoctor doctorContext;
        private readonly IWork workContext;
        private readonly IDepartament departamentContext;

        public ProfileController(HospitalDbContext dbContext, IUser user, IPatient patient, IHospital hospital, IDoctor doctor,
            IWork work, IDepartament departament)
        {
            this.dbContext = dbContext;
            this.userContext = user;
            this.patientContext = patient;
            this.hospitalContext = hospital;
            this.doctorContext = doctor;
            this.workContext = work;
            this.departamentContext = departament;
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

            if (dbContext.userPictureTable.Where(x=>x.id == user.userPictureId && x.picture != null).Any())
            {
                byte[] arr = dbContext.userPictureTable.FirstOrDefault(x => x.id == user.userPictureId).picture;
                userProfile.base64StringPhoto = Convert.ToBase64String(arr);
            }
            
            return Ok(userProfile);
        }

        
        [HttpGet("appoiments/patient")]
        [Authorize]
        public ActionResult<List<AppoimentModel>> getAppoimentsForPatient()
        {
            var patientId = patientContext.getPatientByUserId(Guid.Parse(User.Identity.Name)).id;

            var listOfAppoiments = dbContext.appoimentTable.Where(x=>x.patientId == patientId).ToList();

            var userId = userContext.getUserByPatientId(patientId);

            List<AppoimentModel> appoiments = new List<AppoimentModel>();

            foreach(var item in listOfAppoiments)
            {
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
                    Date = item.dateTime.ToString()

                }) ;
            }

            return Json(appoiments);
        }

        [HttpGet("cases/patient")]
        [Authorize]
        public ActionResult<List<CaseModel>> getCasesForPatient()
        {
            var patientId = patientContext.getPatientByUserId(Guid.Parse(User.Identity.Name)).id;

            var listOfCases = dbContext.caseTable.Where(x => x.patientId == patientId).ToList();

            var user = userContext.getUserByPatientId(patientId);

            List<CaseModel> cases = new List<CaseModel>();

            foreach (var item in listOfCases)
            {
                cases.Add(new CaseModel
                {
                    id = item.id,
                    patientName = $"{user.surname} " +
                    $"{user.name} " +
                    $"{user.middleName}",
                    caseStatus = dbContext.casesStatusTable.Find(item.caseStatusId).statusName,
                    office = dbContext.officeTable.Find(item.officeId),
                    diseaseName = dbContext.diseaseTable.Find(item.diseaseId).name,
                    hospitalName = hospitalContext.getHospitalByCase(item).name,
                    anamnesis = item.anamnesis,
                    treatmentInformation = item.treatmentInformation,
                    createDate = item.createDate.ToString()

                }) ;
            }
            return Json(cases);
        }

        [HttpGet("appoiments/doctor")]
        [Authorize]
        public ActionResult<List<AppoimentModel>> getAppoimentsForDoctor()
        {
            Doctor doctor = doctorContext.getDoctorByUserId(Guid.Parse(User.Identity.Name));
            User userDoctor = userContext.getUserByDoctorId(doctor.id);

            var listOfAppoiments = dbContext.appoimentTable.Where(x => x.doctorId == doctor.id);
            
            List<AppoimentModel> appoiments = new List<AppoimentModel>();

            foreach(var item in listOfAppoiments)
            {
                var userId = userContext.getUserByPatientId(item.patientId);
                appoiments.Add(new AppoimentModel
                {
                    id = item.id,
                    patientName = $"{dbContext.userTable.Find(userId).surname} " +
                    $"{dbContext.userTable.Find(userId).name} " +
                    $"{dbContext.userTable.Find(userId).middleName}",
                    doctorName = $"{userDoctor.surname}" +
                    $"{userDoctor.name} " +
                    $"{userDoctor.middleName}",
                    indexesOfPatient = dbContext.indexesTable.Find(userId),
                    officeName = item.office.name,
                    officeNumberInHospital = item.office.numberInHospital,
                    officeDesc = item.office.additionalInformation,
                    hospitalName = "Тестується",
                    Date = item.dateTime.ToString()
                });
            }

            return appoiments;
        }

        [HttpGet("isDoctor")]
        [Authorize]
        public bool isDoctor()
        {
            return doctorContext.isDoctorExist(Guid.Parse(User.Identity.Name)); 
        }

        [HttpGet("isAdminInHospital")]
        [Authorize]
        public bool isAdminInHospital()
        {
            var doctorId = doctorContext.getDoctorByUserId(Guid.Parse(User.Identity.Name)).id;

            if (doctorContext.isDoctorExist(Guid.Parse(User.Identity.Name)) && workContext.isDoctorExistInWorkTable(doctorId))
                return workContext.getAllWorks
                    .Any(x => x.doctorId == doctorId
                        && x.isAdminInHospital);

            return false;
        }

        [HttpGet("isAdminInDepartament")]
        [Authorize]
        public bool isAdminInDepartament()
        {
            var doctorId = doctorContext.getDoctorByUserId(Guid.Parse(User.Identity.Name)).id;

            if (doctorContext.isDoctorExist(Guid.Parse(User.Identity.Name)) && workContext.isDoctorExistInWorkTable(doctorId))
                return workContext.getAllWorks
                    .Any(x => x.doctorId == doctorId
                        && x.isAdminInDepartament);

            return false;
        }

        [HttpGet("isAdminInSystem")]
        [Authorize]
        public bool isAdminInSystem()
        {
            return userContext.users.Any(x => x.id == Guid.Parse(User.Identity.Name) && x.isAdmin);
        }



        [HttpGet("myHospitals")]
        [Authorize]
        public ActionResult<List<Models.Entities.Hospital>> getMyHospitals()
        {
            var doctorId = doctorContext.getDoctorByUserId(Guid.Parse(User.Identity.Name)).id;

            return hospitalContext.GetHospitalsByOwnerId(doctorId).ToList();
        }

        [HttpGet("myDepartaments")]
        [Authorize]
        public ActionResult<List<Departament>> getMyDepartaments()
        {
            var doctorId = doctorContext.getDoctorByUserId(Guid.Parse(User.Identity.Name)).id;

            return departamentContext.getDepartamentsByOwnerId(doctorId).ToList();
        }
    }
}
