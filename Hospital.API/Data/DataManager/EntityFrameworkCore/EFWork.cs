using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Hospital.API.Data.DataManager.EntityFrameworkCore
{
    
    public class EFWork : IWork
    {
        private readonly HospitalDbContext dbContext;

        public EFWork(HospitalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Work> getAllWorks => dbContext.workTable;

        public bool isDoctorExistInWorkTable(Guid doctorId)
        {
            if (!dbContext.workTable.Any())
            {
                return false;
            }
            if(dbContext.workTable.Any(x=>x.doctorId == doctorId))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
