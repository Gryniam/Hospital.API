using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Hospital.API.Data.DataManager.EntityFrameworkCore
{
    public class EFTime:ITime
    {
        private readonly HospitalDbContext dbContext;

        public EFTime(HospitalDbContext dbContext) { this.dbContext = dbContext; }

        public IEnumerable<Time> getTimeTable => dbContext.timeTable;

        public IEnumerable<Times> getTimesTable => dbContext.timesTable;

        public Time getTimeById(Guid id)
        {
            return dbContext.timeTable.Find(id);
        }
    }
}
