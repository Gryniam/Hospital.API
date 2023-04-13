using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Models.Entities;
using Hospital.API.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Hospital.API.Data.DataManager.EntityFrameworkCore
{
    public class EFUser : IUser
    {
        private readonly HospitalDbContext dbContext;
        private readonly HashPassword hashPassword;
        private readonly IPatient Ipatient;
        private readonly IDoctor Idoctor;

        public IEnumerable<User> users => dbContext.userTable;

        public EFUser(HospitalDbContext context, HashPassword hashPassword, IPatient ipatient, IDoctor iDoctor)
        {
            dbContext = context;
            this.hashPassword = hashPassword;
            Ipatient = ipatient;
            Idoctor = iDoctor;  
        }
        public bool addUser(RegistrationModel registrationModel, Guid id)
        {
            User user = new User();
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            user.id = id;
            user.isAdmin = false;
            user.phoneNumber = registrationModel.phoneNumber;
            user.surname = registrationModel.surname;
            user.name = registrationModel.name;
            user.middleName = registrationModel.middleName;
            user.genderId = dbContext.genderTable.Where(x => x.genderName == registrationModel.gender).FirstOrDefault().id;

            if (user.genderId == default)
            {
                return false;
            }
            if (!Regex.IsMatch(registrationModel.mail, emailPattern) || isIdenticalMail(registrationModel.mail))
            {
                return false;
            }
            user.mail = registrationModel.mail;
            user.passwordHash = hashPassword.Hash(registrationModel.password);
            user.userPictureId = Guid.NewGuid();

            user.birthDate = DateTime.Parse(registrationModel.birthDate).Date;
            user.Age = DateTime.Now.Year - user.birthDate.Year;
            user.settlementId = dbContext.settlementTable.Where(x => x.name == registrationModel.settlementName).FirstOrDefault().id;

            dbContext.userPictureTable.Add(new UserPicture
            {
                id = user.userPictureId,
                picture = null
            });

            dbContext.userTable.Add(user);
            Ipatient.addPatient(user.id);

            return true;
        }

        

        public User getUserById(Guid id)
        {
            return dbContext.userTable.Find(id);
        }

        public User getUserByMail(string mail)
        {
            return dbContext.userTable.FirstOrDefault(x => x.mail == mail);
        }

        public User getUserByPatientId(Guid id)
        {
            return dbContext.userTable.Find(Ipatient.getPatientById(id).UserId);
        }
        public User getUserByDoctorId(Guid id)
        {
            return dbContext.userTable.Find(Idoctor.getDoctorById(id).userId);
        }

        private bool isIdenticalMail(string mail)
        {
            if (dbContext.userTable.FirstOrDefault(x => x.mail == mail) != default)
            {
                return true;
            }
            return false;
        }
    }
}
