using Hospital.API.Models.Entities;
using System;

namespace Hospital.API.Data.DataManager.Interfaces
{
    public interface IPatient
    {
        void addPatient(Guid id);

        Patient getPatientById(Guid id);

        Patient getPatientByUserId(Guid id);
    }
}
