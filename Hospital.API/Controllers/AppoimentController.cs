using Hospital.API.Data;
using Hospital.API.Data.DataManager.EntityFrameworkCore;
using Hospital.API.Data.DataManager.Interfaces;
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
    [ApiController]
    [Route("/[controller]")]
    public class AppoimentController : Controller
    {
        private readonly HospitalDbContext dbContext;
        private readonly IHospital hospitalContext;
        private readonly ICast castContext;
        private readonly IDoctor doctorContext;
        private readonly ILocation locationContext;
        private readonly IUser userContext;
        private readonly IIndexes indexesContext;
        private readonly IPatient patientContext;
        private readonly ITime timeContext;
        private readonly ISpecialty specialtyContext;
        private readonly IAppoiment appoimentContext;

        public AppoimentController(HospitalDbContext dbContext, IHospital hospital, ICast cast, 
            IDoctor doctorContext, ILocation locationContext, IUser userContext, IIndexes indexes, IPatient patientContext, ITime timeContext,
            ISpecialty specialtyContext, IAppoiment appoimentContext)
        {
            this.dbContext = dbContext;
            this.hospitalContext = hospital;
            this.castContext = cast;
            this.doctorContext = doctorContext;
            this.locationContext = locationContext;
            this.userContext = userContext;
            this.indexesContext = indexes;
            this.patientContext = patientContext;
            this.timeContext = timeContext;
            this.specialtyContext = specialtyContext;
            this.appoimentContext = appoimentContext;
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
                if(timeContext.getTimesTable.Any(x=>x.doctorId == doctor.id))
                {
                    doctorModels.Add(castContext.toDoctorModel(doctor));
                }
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
        [HttpGet("/Specialities")]
        [Authorize]
        public ActionResult<List<Specialty>> getSpecialities()
        {
            List<Specialty> specialty = specialtyContext.getSpecialityTable.ToList();
            return Ok(specialty);
        }

        [HttpPost("/Doctor/Time")]
        [Authorize]
        public ActionResult<List<Time>> getFreeTimeOfDoctorInOffice([FromBody] DoctorOfficesModel doctorOffices){

            DateTime getDate = DateTime.Parse(doctorOffices.date).Date;

            if(getDate < DateTime.Now)
            {
                return BadRequest("Дата запису не може бути минулою)))))))");
            }

            var freeTimeOfDoctor = timeContext.getTimesTable
            .Where(item => item.doctorId == doctorOffices.doctorId && item.officeId == doctorOffices.officeId)
            .ToList();

            var result = (from item in freeTimeOfDoctor
                          where !appoimentContext.appoiments.Any(x => x.appoimentTimeId == item.Id && x.dateTime.Date == getDate)
                          select timeContext.getTimeById(item.timeId)).ToList();
            return Ok(result);
        }

        [HttpPost("/Doctor/Offices")]
        [Authorize]
        public ActionResult<List<Offices>> getOfficesOfDoctor([FromBody] HospitalDoctorModel hospitalDoctorModel)
        {
            List<Office> offices = new List<Office>();
            List<Work> works = dbContext.workTable.ToList();
            foreach(var work in works)
            {
                if(work.doctorId == hospitalDoctorModel.doctorId && work.hospitalId == hospitalDoctorModel.hospitalId)
                {
                    offices.Add(dbContext.officeTable.Find(work.officeId));
                }
            }

            return Ok(offices);
        }

        [HttpPost("/SendAppoiment")]
        [Authorize]
        public async Task<IActionResult> createAppoiment([FromBody] SendingModel appoimentSend)
        {
            Appoiment appoiment = new Appoiment();

            appoiment.doctorId = Guid.Parse(appoimentSend.doctorId);
            appoiment.officeId = Guid.Parse(appoimentSend.officeId);

            var userId = userContext.getUserById(Guid.Parse(User.Identity.Name)).id;
            var doctorUserId = userContext.getUserByDoctorId(Guid.Parse(appoimentSend.doctorId)).id;

            

            if(userId == doctorUserId)
            {
                return BadRequest("Лікар не може записатися сам до себе");
            }

            appoiment.id = Guid.NewGuid();

            var indexes = indexesContext.getIndexesOfUser(userId);
            indexes.additionalInformation = appoimentSend.additionalInformation;
            indexesContext.updateIndexesOfUser(indexes, userId);


            appoiment.patientId = patientContext.getPatientByUserId(userId).id;
            var timeId = Guid.Parse(appoimentSend.appoimentTimeId);

            appoiment.appoimentTimeId = timeContext.getTimesTable.Where(x=>x.timeId == timeId).FirstOrDefault().Id;

            if(appoimentContext.appoiments.Any(x=>x.appoimentTimeId == appoiment.appoimentTimeId))
            {
                return BadRequest("На цю годину уже хтось записаний");
            }

            appoiment.dateTime = DateTime.Parse(appoimentSend.date).Date;

            appoimentContext.addAppoiment(appoiment);
            dbContext.SaveChanges();
            return Ok();
        }
    }
}
