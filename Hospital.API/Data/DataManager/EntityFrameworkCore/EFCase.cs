using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Models.Entities;
using System;
using System.Collections.Generic;

namespace Hospital.API.Data.DataManager.EntityFrameworkCore
{
    public class EFCase : ICase
    {
        private readonly HospitalDbContext dbContext;

        public EFCase(HospitalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Case> cases => dbContext.caseTable;

        public Case getCaseById(Guid id)
        {
            return dbContext.caseTable.Find(id);
        }
    }
}
