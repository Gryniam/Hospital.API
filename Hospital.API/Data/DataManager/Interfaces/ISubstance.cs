using Hospital.API.Models.Entities;
using System;
using System.Collections.Generic;

namespace Hospital.API.Data.DataManager.Interfaces
{
    public interface ISubstance
    {
        IEnumerable<Substance> substances { get; }

        IEnumerable<Substance> getAllergySubstance(Guid patientId);
        IEnumerable<Substance> getNoAllergySubstance(Guid patientId);
    }
}
