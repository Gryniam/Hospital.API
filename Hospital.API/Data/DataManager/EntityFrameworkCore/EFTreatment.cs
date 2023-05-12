using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.API.Data.DataManager.EntityFrameworkCore
{
    public class EFTreatment : ITreatment
    {
        private readonly HospitalDbContext dbContext;

        public EFTreatment(HospitalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Treatment> GetTreatmants => dbContext.treatmentTable;

        public IEnumerable<Preparation> GetPreparationsByTreatmantInCase(Guid caseId)
        {
            return (from preparation in dbContext.preparationTable.ToList()
                    where dbContext.treatmentTable.Any(x => x.caseId == caseId && x.preparationId == preparation.id)
                    select preparation);
        }
    }
}
