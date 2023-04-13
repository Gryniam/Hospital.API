﻿using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace Hospital.API.Data.DataManager.EntityFrameworkCore
{
    public class EFHospital : IHospital
    {
        private readonly HospitalDbContext dbContext;

        public EFHospital(HospitalDbContext context)
        {
            dbContext = context;
        }

        public IEnumerable<Models.Entities.Hospital> GetHospitals => dbContext.hospitalTable;

        public Models.Entities.Hospital getHospitalByCase(Case insertedCase)
        {
            var depId = dbContext.officesTable.Where(x => x.id == insertedCase.officeId).FirstOrDefault().departamentId;

            if (depId == Guid.Empty || depId == default)
            {
                return new Models.Entities.Hospital
                {
                    name = "Відсутня лікарня"
                };
            }
            else
            {
                var hospitalId = dbContext.departamentTable.Where(x=>x.id == depId).FirstOrDefault().hospitalId;
                if(hospitalId == default || hospitalId == Guid.Empty)
                {
                    return dbContext.hospitalTable.Where(x=>x.id == hospitalId).FirstOrDefault();
                }
                else
                {
                    return new Models.Entities.Hospital
                    {
                        name = "Відсутня лікарня"
                    };
                }
            }


        }

        public IEnumerable<Models.Entities.Hospital> GetHospitalsByOwnerId(Guid ownerId)
        {
            return dbContext.workTable
            .Where(w => w.doctorId == ownerId && w.isAdminInHospital)
            .Join(dbContext.hospitalTable,
                    work => work.hospitalId,
                    hospital => hospital.id,
                    (work, hospital) => hospital);
        }
    }
}
