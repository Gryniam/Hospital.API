using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Models.Entities;
using System.Collections.Generic;

namespace Hospital.API.Data.DataManager.EntityFrameworkCore
{
    public class EFSpecialty : ISpecialty
    {
        private readonly HospitalDbContext dbContext;

        public EFSpecialty(HospitalDbContext dbContext) { this.dbContext = dbContext; }
        public IEnumerable<Specialty> getSpecialityTable => dbContext.specialityTable;
    }
}
