using Hospital.API.Data;
using Hospital.API.Data.DataManager.EntityFrameworkCore;
using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Migrations;
using Hospital.API.Models.Entities;
using Hospital.API.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Cryptography.X509Certificates;
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
        private readonly ILocation locationContext;
        private readonly IUser userContext;

        public AppoimentController(HospitalDbContext dbContext, IHospital hospital, ICast cast, 
            IDoctor doctorContext, ILocation locationContext, IUser userContext)
        {
            this.dbContext = dbContext;
            this.hospitalContext = hospital;
            this.castContext = cast;
            this.doctorContext = doctorContext;
            this.locationContext = locationContext;
            this.userContext = userContext;
        }

        [HttpGet("/Hospitals")]
        [Authorize]
        public ActionResult<List<HospitalModel>> getHospitals()
        {
            List<Models.Entities.Hospital> hospitalList = hospitalContext.GetHospitals.ToList();

            List<HospitalModel> hospitalModels = new List<HospitalModel>();

            foreach (var hospital in hospitalList)
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

            foreach (var doctor in doctors)
            {
                doctorModels.Add(castContext.toDoctorModel(doctor));
            }

            return Ok(doctorModels);
        }

        [HttpGet("/Locations")]
        [Authorize]
        public ActionResult<List<LocationView>> getLocations()
        {
            return Ok(new LocationView
            {
                regions = locationContext.regions.ToList(),
                districts = locationContext.districts.ToList(),
                settlements = locationContext.settlements.ToList()
            });
        }

        [HttpPost("/Doctor/Time")]
        [Authorize]
        public ActionResult<List<Time>> getFreeTimeOfDoctorInOffice([FromBody] Guid doctorId, Guid officeId, string date){

            DateTime getDate = DateTime.Parse(date).Date;
            var appoimentsWithThisDate = dbContext.appoimentTable.Where(x=>x.dateTime.Day.Equals(getDate)).ToList();


            var allTimeOfDoctor = dbContext.timeTable.Where(x => dbContext.timesTable.Any(y => y.doctorId == doctorId)
            && dbContext.timesTable.Any(x => x.officeId == officeId)).ToList();



            List<Time> freeTime = new List<Time>();
            foreach(var time in allTimeOfDoctor)
            {
                if(!dbContext.appoimentTable.Any(x=>x.appoimentTimeId == time.id && x.dateTime.Date == getDate))
                {
                    freeTime.Add(time);
                }
            }
            return Ok(freeTime) ?? null;
        }

        [HttpPost("/Doctor/Offices")]
        [Authorize]
        public ActionResult<List<Offices>> getOfficesOfDoctor([FromBody] Guid hospitalId, Guid doctorId)
        {
            var offices = dbContext.officeTable.Where(x => dbContext.workTable.Any(x => x.hospitalId == hospitalId));
            var officesInHospital = new List<Office>();
            foreach (var item in offices)
            {
                if (dbContext.workTable.Any(x => x.officeId == item.id  && x.doctorId == doctorId))
                {
                    officesInHospital.Add(item);
                }
            }

            return Ok(officesInHospital);
        }

        [HttpPost("/SendAppoiment")]
        [Authorize]
        public async Task<IActionResult> createAppoiment([FromBody] Appoiment appoiment)
        {
            var userId = userContext.getUserById(Guid.Parse(User.Identity.Name)).id;
            var doctorUserId = userContext.getUserByDoctorId(appoiment.doctorId).id;

            if(userId == doctorUserId)
            {
                return BadRequest("Лікар не може записатися сам до себе");
            }

            dbContext.appoimentTable.Add(appoiment);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
