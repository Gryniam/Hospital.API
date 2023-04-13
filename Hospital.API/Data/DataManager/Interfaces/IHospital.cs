using Hospital.API.Models.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Hospital.API.Data.DataManager.Interfaces
{
    public interface IHospital
    {
        IEnumerable<Models.Entities.Hospital> GetHospitals { get; }

        IEnumerable<Models.Entities.Hospital> GetHospitalsByOwnerId(Guid ownerId);

        Models.Entities.Hospital getHospitalByCase(Case insertedCase);
    }
}
