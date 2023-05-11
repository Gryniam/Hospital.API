using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.API.Data.DataManager.EntityFrameworkCore
{
    public class EFSubstance : ISubstance
    {
        private readonly HospitalDbContext dbContext;

        public EFSubstance(HospitalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Substance> substances => dbContext.substanceTable;

        public IEnumerable<Substance> getAllergySubstance(Guid patientId)
        {
            return dbContext.substanceTable
            .Join(dbContext.allergiesTable.Where(a => a.patiendId == patientId), s => s.id, a => a.substanceId, (s, a) => s);
        }

        public IEnumerable<Substance> getNoAllergySubstance(Guid patientId)
        {
            return dbContext.substanceTable
            .Where(s => !dbContext.allergiesTable.Any(a => a.patiendId == patientId && a.substanceId == s.id));
        }
    }
}
