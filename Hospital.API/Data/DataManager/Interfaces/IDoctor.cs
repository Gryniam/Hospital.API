using Hospital.API.Models.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Hospital.API.Data.DataManager.Interfaces
{
    public interface IDoctor
    {
        IEnumerable<Doctor> getAllDoctors();
        void addDoctor(Guid id);

        Doctor getDoctorById(Guid id);  

        Doctor getDoctorByUserId(Guid userId);

        bool isDoctorExist(Guid userId);
    }
}
