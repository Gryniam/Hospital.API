using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital.API.Data.DataManager.EntityFrameworkCore
{
    public class EFDepartament : IDepartament
    {
        private readonly HospitalDbContext dbContext;

        public EFDepartament(HospitalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<Departament> departaments => dbContext.departamentTable;

        public IEnumerable<Departament> getDepartamentsByOwnerId(Guid ownerId)
        {
            return from work in dbContext.workTable
            join department in dbContext.departamentTable on work.departamentId equals department.id
            where work.doctorId == ownerId && work.isAdminInDepartament
                   select department;
        }
    }
}
