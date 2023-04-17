using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Data;
using Hospital.API.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Hospital.API.Models.Entities;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Hospital.API.Data.DataManager.EntityFrameworkCore
{
    public class EFIndexes : IIndexes
    {
        private readonly HospitalDbContext dbContext;
        private readonly ILocation locationContext;
        private readonly IPatient patientContext;

        public EFIndexes(HospitalDbContext dbContext, ILocation locationContext, IPatient patientContext, IUser userContext)
        {
            this.dbContext = dbContext;
            this.locationContext = locationContext;
            this.patientContext = patientContext;
        }
        public IEnumerable<Indexes> indexes => dbContext.indexesTable;

        public void addIndexesToUser(Guid userId)
        {
            var patientId = patientContext.getPatientByUserId(userId).id;
            Indexes indexes = new Indexes
            {
                id = Guid.NewGuid(),
                patiendId = patientId
            };
            dbContext.indexesTable.Add(indexes);
            dbContext.SaveChanges();
        }

        public Indexes getIndexesByPatientId(Guid patientId)
        {
            return dbContext.indexesTable.Where(x => x.patiendId == patientId).FirstOrDefault();
        }

        public Indexes getIndexesOfUser(Guid userId)
        {
            Guid patientId = patientContext.getPatientByUserId(userId).id;

            return getIndexesByPatientId(patientId);
        }

        public void updateIndexesOfUser(Indexes newIndexes, Guid userId)
        {
            var currentIndexes = getIndexesOfUser(userId);

            currentIndexes.height = newIndexes.height;
            currentIndexes.weight = newIndexes.weight;
            currentIndexes.bloodPressure = newIndexes.bloodPressure;
            currentIndexes.pulse = newIndexes.pulse;
            currentIndexes.bloodSugar = newIndexes.bloodSugar;
            currentIndexes.bodyTemperature = newIndexes.bodyTemperature;
            currentIndexes.additionalInformation = newIndexes.additionalInformation;

            dbContext.indexesTable.Update(currentIndexes);
            dbContext.SaveChanges();
        }
    }
}
