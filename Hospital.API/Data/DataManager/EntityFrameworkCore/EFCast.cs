using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Models.Entities;
using Hospital.API.Models.ViewModels;
using System;
using System.Linq;

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

            model.currentDistrictName = locationContext.getDistrictBySettlementId(
                locationContext.getSettlementById(user.settlementId).id).name;

            model.currentRegionName = locationContext.getRegionBySettlementId(user.settlementId).name;

            model.noAllergySubstance = dbContext.allergiesTable
                    .Where(a => a.patiendId != patientId)
                    .Select(a => a.substance)
                    .Distinct()
                    .ToList();

            model.AllergySubstance = model.noAllergySubstance = dbContext.allergiesTable
                    .Where(a => a.patiendId == patientId)
                    .Select(a => a.substance)
                    .Distinct()
                    .ToList();

            model.regions = locationContext.regions.ToList();
            model.districts = locationContext.districts.ToList();
            model.settlements = locationContext.settlements.ToList();

            model.indexes = indexesContext.getIndexesByPatientId(patientContext.getPatientByUserId(user.id).id);

            return model;
        }

        public RegistrationModel toRegistrationModel(User user)
        {
            return new RegistrationModel {
                surname = user.surname,
                name = user.name,
                middleName = user.middleName,
                password = string.Empty,
                mail = user.mail,
                gender = dbContext.genderTable.Find(user.genderId).genderName,
                birthDate = user.birthDate.ToString(),
                phoneNumber = user.phoneNumber,
                settlementName = dbContext.settlementTable.Find(user.settlementId).name
            };
        }

        public UserProfileModel toUserProFileModel(User user)
        {
           throw new System.NotImplementedException();
        }
    }
}
