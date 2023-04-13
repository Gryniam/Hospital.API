using Hospital.API.Models.Entities;
using System;
using System.Collections.Generic;

namespace Hospital.API.Data.DataManager.Interfaces
{
    public interface IWork
    {
        IEnumerable<Work> getAllWorks {  get; }

        bool isDoctorExistInWorkTable(Guid doctorId);
    }
}
