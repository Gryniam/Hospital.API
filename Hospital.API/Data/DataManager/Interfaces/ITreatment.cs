using Hospital.API.Models.Entities;
using System;
using System.Collections.Generic;

namespace Hospital.API.Data.DataManager.Interfaces
{
    public interface ITreatment
    {

        IEnumerable<Treatment> GetTreatmants { get; }

        IEnumerable<Preparation> GetPreparationsByTreatmantInCase(Guid caseId);
    }
}
