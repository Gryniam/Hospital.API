using Hospital.API.Data;
using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Models.Entities;
using Hospital.API.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Hospital.API.Controllers
{

    [ApiController]
    [Route("/[controller]")]
    public class AppoimentManagmentController : Controller
    {
        private readonly HospitalDbContext dbContext;
        private readonly ICast castContext;
        public AppoimentManagmentController(HospitalDbContext dbContext, ICast castContext) 
        { 
            this.dbContext = dbContext;
            this.castContext = castContext;
        }

        [HttpPost("/Appoiment")]
        [Authorize]
        public AppoimentModel getDataOfAppoiment([FromBody] Guid appoimentId)
        {
            Appoiment appoiment = dbContext.appoimentTable.Find(appoimentId);
            AppoimentModel model = castContext.toAppoimentModel(appoiment);

           
            return model;
        }

        [HttpPost("/Symptoms")]
        [Authorize]
        public ActionResult<List<Symptom>> getSymptomByString([FromBody] string inputString)
        {
            List<Symptom> symptoms = dbContext.symptomTable.Where(x => x.name == inputString).ToList();

            return Ok(symptoms);
        }

        [HttpPost("/Diseases")]
        [Authorize]
        public ActionResult<List<Disease>> getTreatmentsBySymptoms([FromBody] List<String> symptomsInput)
        {
            List<Symptom> symptomsList = (from symptom in symptomsInput
                                where dbContext.symptomTable.Any(x => x.name == symptom)
                                select dbContext.symptomTable.Where(x => x.name == symptom).FirstOrDefault()).ToList();


            List<Disease> diseasesList = dbContext.diseaseTable
                    .Select(disease => new Disease
                     {
                         id = disease.id,
                         name = disease.name,
                         symptoms = dbContext.symptomsTable
                             .Where(symptom => symptom.diseaseId == disease.id)
                             .Select(symptom => dbContext.symptomTable.FirstOrDefault(s => s.id == symptom.symptomId))
                             .ToList()
                     })
                     .ToList();

            //List<Disease> resultList = new List<Disease>();

            //foreach(var disease in diseasesList)
            //{
            //    bool all = true;
            //    foreach(var item in symptomsList)
            //    {
            //        if(!disease.symptoms.Any(x=>x.id == item.id))
            //        {
            //            all = false;
            //        }
            //    }
            //    if (all)
            //    {
            //        resultList.Add(disease);
            //    }
            //}    
            var resultList = diseasesList.Where(disease => symptomsList.All(
                symptom => disease.symptoms.Any(
                    diseaseSymptom => diseaseSymptom.id == symptom.id))).ToList();


            return Ok(resultList);  
        }


        [HttpPost("/CreateCase")]
        [Authorize]
        public async Task<IActionResult> createCase([FromBody] CaseRequestModel caseInput)
        {
            if(caseInput == null) {
                return BadRequest("Дані не надходять");
            }
            Case resultCase = new Case();

            resultCase.id = Guid.NewGuid();
            resultCase.patientId = caseInput.patientId;
            resultCase.doctorId = caseInput.doctorId;
            resultCase.diseaseId = caseInput.diseaseId;
            resultCase.officeId = caseInput.officeId;

            resultCase.anamnesis = string.Empty;
            resultCase.treatmentInformation = string.Empty;
            resultCase.createDate = DateTime.Now;

            if (dbContext.casesStatusTable.Any())
            {
                resultCase.caseStatusId = dbContext.casesStatusTable.First().id;
            }

            dbContext.caseTable.Add(resultCase);
            dbContext.SaveChanges();

            return Ok(resultCase);
        }
        


    }
}
