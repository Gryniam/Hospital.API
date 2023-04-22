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
        private readonly IUser userContext;

        public EFCast(HospitalDbContext dbContext, ILocation locationContext, IPatient patientContext, IUser userContext, 
            IIndexes indexesContext)
        {
            this.dbContext = dbContext;
            this.locationContext = locationContext;
            this.patientContext = patientContext;
            this.indexesContext = indexesContext;
            this.userContext = userContext;
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

        public DoctorModel toDoctorModel(Doctor currentDoctor)
        {
            User user = userContext.getUserByDoctorId(currentDoctor.id);
            DoctorModel doctorModel = new DoctorModel();

            doctorModel.doctor.id = currentDoctor.id;
            doctorModel.doctor.userId = currentDoctor.userId;
            doctorModel.doctor.additionalInformation = currentDoctor.additionalInformation;
            doctorModel.name = $"{user.surname} {user.name} {user.middleName}";
            doctorModel.mail = user.mail;
            doctorModel.age = user.Age.ToString();
            doctorModel.phoneNumber = user.phoneNumber;

            return doctorModel;
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

        public HospitalModel toHospitalModel(Models.Entities.Hospital hospital)
        {
            HospitalModel hospitalModel = new HospitalModel();

            hospitalModel.id = hospital.id;
            hospitalModel.name = hospital.name;
            hospitalModel.regionDesc = dbContext.regionTable.Find(hospital.regionId).name;
            hospitalModel.disctrictDesc = dbContext.districtTable.Find(hospital.districtId).name;
            hospitalModel.settlementDesc = dbContext.settlementTable.Find(hospital.settlementId).name;
            hospitalModel.TypeDesc = dbContext.typeTable.Find(hospital.typeId).name;
            hospitalModel.contactNumber = hospital.contactNumber;
            hospitalModel.adressDesc = hospital.adressDescription;
            hospitalModel.additionalInformation = hospital.description;

            return hospitalModel;
            
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
