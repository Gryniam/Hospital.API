using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Models.Entities;
using System;
using System.Linq;

namespace Hospital.API.Data.DataManager.EntityFrameworkCore
{
    public class EFPatient:IPatient
    {
        private readonly HospitalDbContext dbContext;

        public EFPatient(HospitalDbContext context)
        {
            dbContext = context;
        }

        public async void addPatient(Guid id)
        {
            await dbContext.patientTable.AddAsync(new Patient
            {
                id = Guid.NewGuid(),
                UserId = id
            });
        }

        public Patient getPatientById(Guid id)
        {
            return dbContext.patientTable.Find(id);
        }

        public Patient getPatientByUserId(Guid id)
        {
            return dbContext.patientTable.First(x => x.UserId == id);
        }
    }
}
