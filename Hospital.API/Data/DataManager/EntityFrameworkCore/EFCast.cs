using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Models.Entities;
using Hospital.API.Models.ViewModels;
using System;
using System.Linq;
using System.Reflection;

namespace Hospital.API.Data.DataManager.EntityFrameworkCore
{
    public class EFCast : ICast
    {
        private readonly HospitalDbContext dbContext;
        private readonly ILocation locationContext;
        private readonly IPatient patientContext;
        private readonly IIndexes indexesContext;

        public EFCast(HospitalDbContext dbContext, ILocation locationContext, IPatient patientContext, IUser userContext, IIndexes indexesContext)
        {
            this.dbContext = dbContext;
            this.locationContext = locationContext;
            this.patientContext = patientContext;
            this.indexesContext = indexesContext;
        }

        public Indexes fromIndexesModel(IndexesModel indexesModel)
        {
            Indexes indexes = new Indexes();

            indexes.height = float.Parse(indexesModel.height);
            indexes.weight = float.Parse(indexesModel.weight);
            indexes.bloodPressure = indexesModel.bloodPressure;
            indexes.pulse = int.Parse(indexesModel.pulse);
            indexes.bloodSugar = float.Parse(indexesModel.bloodSugar);
            indexes.bodyTemperature = float.Parse(indexesModel.bodyTemperature);
            indexes.additionalInformation = indexesModel.additionalInformation;

            return indexes;
        }

        public AppoimentModel toAppoimentModel(Appoiment appoiment)
        {
            throw new System.NotImplementedException();
        }

        public CaseModel toCaseModel(Case currentCase)
        {
            throw new System.NotImplementedException();
        }

        public EditProfileModel toEditProfileModel(User user)
        {
            Guid patientId = patientContext.getPatientByUserId(user.id).id;
            EditProfileModel model = new EditProfileModel();
            model.registrationModel = toRegistrationModel(user);

            model.currentDistrictName = locationContext.getDistrictBySettlementId(user.settlementId).name;


            model.currentRegionName = locationContext.getRegionBySettlementId(user.settlementId).name;


            model.noAllergySubstance = dbContext.substanceTable
            .Where(s => !dbContext.allergiesTable.Any(a => a.patiendId == patientId && a.substanceId == s.id))
             .ToList();

            model.AllergySubstance = dbContext.substanceTable
            .Join(dbContext.allergiesTable.Where(a => a.patiendId == patientId), s => s.id, a => a.substanceId, (s, a) => s)
            .ToList();

            model.regions = locationContext.regions.ToList();
            model.districts = locationContext.districts.ToList();
            model.settlements = locationContext.settlements.ToList();

            model.indexes = indexesContext.getIndexesByPatientId(patientContext.getPatientByUserId(user.id).id);

            return model;
        }

        public RegistrationModel toRegistrationModel(User user)
        {
            RegistrationModel regModel = new RegistrationModel();
            regModel.surname = user.surname;
            regModel.name = user.name;
            regModel.middleName = user.middleName;
                regModel.password = string.Empty;
                regModel.mail = user.mail;
                regModel.gender = dbContext.genderTable.Find(user.genderId).genderName;
                regModel.birthDate = user.birthDate.ToString();
                regModel.phoneNumber = user.phoneNumber;
                regModel.settlementName = dbContext.settlementTable.Find(user.settlementId).name;

            return regModel;

            //return new RegistrationModel {
            //    surname = user.surname,
            //    name = user.name,
            //    middleName = user.middleName,
            //    password = string.Empty,
            //    mail = user.mail,
            //    gender = dbContext.genderTable.Find(user.genderId).genderName,
            //    birthDate = user.birthDate.ToString(),
            //    phoneNumber = user.phoneNumber,
            //    settlementName = dbContext.settlementTable.Find(user.settlementId).name
            //};
        }

        public UserProfileModel toUserProFileModel(User user)
        {
           throw new System.NotImplementedException();
        }
    }
}
