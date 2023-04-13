using Hospital.API.Models.Entities;
using Hospital.API.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace Hospital.API.Data.DataManager.Interfaces
{
    public interface IUser
    {
        IEnumerable<User> users { get; }
        bool addUser(RegistrationModel registrationModel, Guid id);

        User getUserById(Guid id);

        User getUserByMail(string mail);

        User getUserByPatientId(Guid id);

        User getUserByDoctorId(Guid id);
    }
}
