using Hospital.API.Data;
using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Models.Entities;
using Hospital.API.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hospital.API.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class CaseManagmentController : Controller
    {
        private readonly HospitalDbContext dbContext;

        private readonly ICase caseContext;

        private readonly ICast castContext;

        private readonly ISubstance substanceContext;

        private readonly IIndexes indexesContext;
        public CaseManagmentController(HospitalDbContext hospitalDbContext, ICase caseContext, ICast castContext,
            ISubstance substanceContext, IIndexes indexesContext)
        {
            this.dbContext = hospitalDbContext;
            this.caseContext = caseContext;
            this.castContext = castContext;
            this.substanceContext = substanceContext;
            this.indexesContext = indexesContext;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> getCase([FromBody] Guid caseId)
        {

            if(caseId.ToString().IsNullOrEmpty())
            {
                return BadRequest("Case Id is clear");
            }
            Case inputCase = caseContext.getCaseById(caseId);
            CaseModel model = castContext.toCaseModel(inputCase);

            return Ok(model);
        }

        [HttpPost("/getStatuses")]
        [Authorize]
        public List<CaseStatus> getCaseStatuses()
        {
            return dbContext.casesStatusTable.ToList();
        }

        [HttpPost("/Allergens")]
        [Authorize]
        public List<Substance> getSubstancesOfWithAllergens([FromBody]Guid patientId)
        {
            return substanceContext.getAllergySubstance(patientId).ToList();
        }

        [HttpPost("/Treatment")]
        [Authorize]
        public List<Preparation> getTreatment([FromBody]Guid caseId)
        {
           var patientId = caseContext.getCaseById(caseId).patientId;

           

           List<Preparation> currentTreatment = (from preparation in dbContext.preparationTable.ToList()
                                                 where dbContext.treatmentTable.Any(x => x.caseId == caseId && x.preparationId == preparation.id)
                                                 select preparation).ToList();

            List<Substance> allergyPreparations = substanceContext.getAllergySubstance(patientId).ToList();

            //List<Preparation> resultList = new List<Preparation>();
            //foreach (var item in dbContext.preparationsTable.ToList())
            //{
            //    if(!currentTreatment.Any(x=>x.id != item.preparationId) && !allergyPreparations.Any(x=>x.id != item.substanceId))
            //    {
            //        resultList.Add(dbContext.preparationTable.Find(item.preparationId));
            //    }
            //}
            List<Preparation> resultList = dbContext.preparationsTable
                .ToList()
                .Where(item => !currentTreatment.Any(x => x.id != item.preparationId)
                                && !allergyPreparations.Any(x => x.id != item.substanceId))
                .Select(item => dbContext.preparationTable.Find(item.preparationId))
                .ToList();



            return resultList;
        }
        [HttpPost("/Indexes")]
        [Authorize]
        public Indexes getIndexes([FromBody] Guid caseId)
        {
            var patientId = caseContext.getCaseById(caseId).patientId;

            return indexesContext.getIndexesByPatientId(patientId);
        }

        [HttpPut]
        [Authorize]
        public async Task<IActionResult> updateCase([FromBody] CaseModel caseModel)
        {
            Case caseForUpdate = castContext.fromCaseModel(caseModel);

            dbContext.caseTable.Update(caseForUpdate);
            return Ok();
        }
    }
}
