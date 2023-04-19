using Hospital.API.Models.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Hospital.API.Data.DataManager.Interfaces
{
    public interface IIndexes
    {
        void addIndexesToUser(Guid userId);

        void addIndexesToPatient(Guid patientId);

        IEnumerable<Indexes> indexes { get; }

        Indexes getIndexesOfUser(Guid userId);

        Indexes getIndexesByPatientId(Guid patientId);

        void updateIndexesOfUser(Indexes newIndexes, Guid userId);
    }
}
