using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public IEnumerable<Doctor> getAllDoctors()
        {
            return dbContext.doctorTable;
        }

        public Doctor getDoctorById(Guid id)
        {
           return dbContext.doctorTable.Find(id);
        }

        public Doctor getDoctorByUserId(Guid userId)
        {

            var result = dbContext.doctorTable.Where(x => x.userId == userId).FirstOrDefault();

            if(result != default)
            {
                return result;
            }
            else
            {
                return null;
            }
        }

        public List<Doctor> getDoctorsByHospital(Guid hospitalId)
        {
            List<Doctor> doctors = new List<Doctor>();
            foreach(var doctor in dbContext.workTable)
            {
                if(doctor.hospitalId == hospitalId)
                {
                    var findedDoctor = dbContext.doctorTable.Find(doctor.doctorId);
                    doctors.Add(findedDoctor);
                }
            }

            return doctors;
        }

        public bool isDoctorExist(Guid userId)
        {
            return dbContext.doctorTable.Any(x => x.userId == userId);
        }
    }
}
