﻿using Hospital.API.Data;
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
        private readonly ICast castContext;
        private readonly ICase caseContext;

        public ProfileController(HospitalDbContext dbContext, IUser user, IPatient patient, IHospital hospital, IDoctor doctor,
            IWork work, IDepartament departament, ICast castContext, ICase caseContext)
        {
            this.dbContext = dbContext;
            this.userContext = user;
            this.patientContext = patient;
            this.hospitalContext = hospital;
            this.doctorContext = doctor;
            this.workContext = work;
            this.departamentContext = departament;
            this.castContext = castContext;
            this.caseContext = caseContext;
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

            List<AppoimentModel> appoiments = new List<AppoimentModel>();

            foreach(var item in listOfAppoiments)
            {
                item.office = dbContext.officeTable.Find(item.officeId);

                appoiments.Add(castContext.toAppoimentModel(item));
            }

            return Json(appoiments);
        }

        [HttpGet("cases/patient")]
        [Authorize]
        public ActionResult<List<CaseModel>> getCasesForPatient()
        {
            var patientId = patientContext.getPatientByUserId(Guid.Parse(User.Identity.Name)).id;

            var listOfCases = dbContext.caseTable.Where(x => x.patientId == patientId).ToList();

            List<CaseModel> cases = new List<CaseModel>();

            foreach (var item in listOfCases)
            {
                cases.Add(castContext.toCaseModel(item));

            }
            return Json(cases);
        }
        [HttpGet("cases/doctor")]
        [Authorize]
        public List<CaseModel> getCasesForDoctor()
        {
            List<CaseModel> caseModels = new List<CaseModel>();
            var doctorId = doctorContext.getDoctorByUserId(Guid.Parse(User.Identity.Name)).id;

            var cases = caseContext.cases.Where(x=>x.doctorId == doctorId).ToList();
            foreach (var item in cases)
            {
                caseModels.Add(castContext.toCaseModel(item));
            }

            return caseModels;
        }

        [HttpGet("appoiments/doctor")]
        [Authorize]
        public ActionResult<List<AppoimentModel>> getAppoimentsForDoctor()
        {
            Doctor doctor = doctorContext.getDoctorByUserId(Guid.Parse(User.Identity.Name));

            var listOfAppoiments = dbContext.appoimentTable.Where(x => x.doctorId == doctor.id).ToList();
            
            List<AppoimentModel> appoiments = new List<AppoimentModel>();

            foreach(var item in listOfAppoiments)
            {
                appoiments.Add(castContext.toAppoimentModel(item));
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
            var doctor = doctorContext.getDoctorByUserId(Guid.Parse(User.Identity.Name));
            if(doctor == null)
            {
                return false;
            }

            if (doctorContext.isDoctorExist(Guid.Parse(User.Identity.Name)) && workContext.isDoctorExistInWorkTable(doctor.id))
                return workContext.getAllWorks
                    .Any(x => x.doctorId == doctor.id
                        && x.isAdminInHospital);

            return false;
        }

        [HttpGet("isAdminInDepartament")]
        [Authorize]
        public bool isAdminInDepartament()
        {
            var doctor = doctorContext.getDoctorByUserId(Guid.Parse(User.Identity.Name));
            if(doctor == null)
            {
                return false;
            }

            if (doctorContext.isDoctorExist(Guid.Parse(User.Identity.Name)) && workContext.isDoctorExistInWorkTable(doctor.id))
                return workContext.getAllWorks
                    .Any(x => x.doctorId == doctor.id
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
            var doctor = doctorContext.getDoctorByUserId(Guid.Parse(User.Identity.Name));

            if(doctor == null)
            {
                return null;
            }

            return hospitalContext.GetHospitalsByOwnerId(doctor.id).ToList();
        }

        [HttpGet("myDepartaments")]
        [Authorize]
        public ActionResult<List<Departament>> getMyDepartaments()
        {
            var doctor = doctorContext.getDoctorByUserId(Guid.Parse(User.Identity.Name));

            if (doctor == null)
            {
                return null;
            }

            return departamentContext.getDepartamentsByOwnerId(doctor.id).ToList();
        }
    }
}
