using Hospital.API.Models.Entities;
using System;

namespace Hospital.API.Data.DataManager.Interfaces
{
    public interface IDoctor
    {
        void addDoctor(Guid id);

        Doctor getDoctorById(Guid id);  
    }
}
