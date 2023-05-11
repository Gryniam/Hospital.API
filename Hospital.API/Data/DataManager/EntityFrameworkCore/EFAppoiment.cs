using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Models.Entities;
using System.Collections.Generic;

namespace Hospital.API.Data.DataManager.EntityFrameworkCore
{
    public class EFAppoiment : IAppoiment
    {
        private readonly HospitalDbContext dbContext;

        public EFAppoiment(HospitalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Appoiment> appoiments => dbContext.appoimentTable;

        public void addAppoiment(Appoiment appoiment)
        {
            dbContext.appoimentTable.Add(appoiment);
            dbContext.SaveChanges();
        }

        public void removeAppoiment(Appoiment appoiment)
        {
            dbContext.appoimentTable.Remove(appoiment);
            dbContext.SaveChanges();
        }
    }
}
