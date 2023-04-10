using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Models.Entities;
using System;

namespace Hospital.API.Data.DataManager.EntityFrameworkCore
{
    public class EFDoctor : IDoctor
    {
        private readonly HospitalDbContext dbContext;

        public EFDoctor(HospitalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async void addDoctor(Guid id)
        {
            await dbContext.doctorTable.AddAsync(new Doctor
            {
                id = Guid.NewGuid(),
                userId = id,
                additionalInformation = null,
            }) ;
        }

        public Doctor getDoctorById(Guid id)
        {
           return dbContext.doctorTable.Find(id);
        }
    }
}
