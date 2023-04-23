using Hospital.API.Data;
using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Migrations;
using Hospital.API.Models.Entities;
using Hospital.API.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Hospital.API.Controllers
{
    public class AppoimentController : Controller
    {
        private readonly HospitalDbContext dbContext;
        private readonly IHospital hospitalContext;
        private readonly ICast castContext;
        private readonly IDoctor doctorContext;

        public AppoimentController(HospitalDbContext dbContext, IHospital hospital, ICast cast, IDoctor doctorContext)
        {
            this.dbContext = dbContext;
            this.hospitalContext = hospital;
            this.castContext = cast;
            this.doctorContext = doctorContext;
        }

        [HttpGet("/Hospitals")]
        [Authorize]
        public ActionResult<List<HospitalModel>> getHospitals()
        {
            List<Models.Entities.Hospital> hospitalList = hospitalContext.GetHospitals.ToList();

            List<HospitalModel> hospitalModels = new List<HospitalModel>();

            foreach(var hospital in hospitalList)
            {
                hospitalModels.Add(castContext.toHospitalModel(hospital));
            }

            return Json(hospitalModels);
        }

        [HttpPost("/Doctors")]
        [Authorize]
        public ActionResult<List<DoctorModel>> getDoctors([FromBody] Guid hospitalId)
        {
            List<Doctor> doctors = doctorContext.getDoctorsByHospital(hospitalId).ToList();

            List<DoctorModel> doctorModels = new List<DoctorModel>();

            foreach(var doctor in doctors)
            {
                doctorModels.Add(castContext.toDoctorModel(doctor);
            }

            return Json(doctorModels);
        }

    }
}
