using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Models.Entities;
using Hospital.API.Models.ViewModels;
using Microsoft.Identity.Client;
using System;
using System.Linq;
using System.Reflection;
using IUser = Hospital.API.Data.DataManager.Interfaces.IUser;

namespace Hospital.API.Data.DataManager.EntityFrameworkCore
{
    public class EFCast : ICast
    {
        private readonly HospitalDbContext dbContext;
        private readonly ILocation locationContext;
        private readonly IPatient patientContext;
        private readonly IIndexes indexesContext;
        private readonly IUser userContext;
        private readonly IHospital hospitalContext;

        public EFCast(HospitalDbContext dbContext, ILocation locationContext, IPatient patientContext, IUser userContext, 
            IIndexes indexesContext, IHospital hospitalContext)
        {
            this.dbContext = dbContext;
            this.locationContext = locationContext;
            this.patientContext = patientContext;
            this.indexesContext = indexesContext;
            this.userContext = userContext;
            this.hospitalContext = hospitalContext;
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
            var userPatient = userContext.getUserByPatientId(appoiment.patientId);

            var userDoctor = userContext.getUserByDoctorId(appoiment.doctorId);

            var office = dbContext.officeTable.Find(appoiment.officeId);
            AppoimentModel appoimentModel = new AppoimentModel();

            appoimentModel.id = appoiment.id;

            appoimentModel.patient = toRegistrationModel(userPatient);

            appoimentModel.patientId = appoiment.patientId;

            appoimentModel.doctor =toRegistrationModel(userDoctor);

            appoimentModel.doctorId = appoiment.doctorId;


            appoimentModel.indexesOfPatient = indexesContext.getIndexesByPatientId(appoiment.patientId);

            appoimentModel.officeName = office.name;

            appoimentModel.officeId = office.id;

            appoimentModel.officeNumberInHospital = office.numberInHospital;

            appoimentModel.officeDesc = office.additionalInformation;

            appoimentModel.hospitalName = hospitalContext.getHospitalByOfficeId(appoiment.officeId).name;

            appoimentModel.Date = appoiment.dateTime.Date.ToString().Split(" ")[0];

            appoimentModel.Time = dbContext.timeTable.Find(dbContext.timesTable.Find(appoiment.appoimentTimeId).timeId).time;

            return appoimentModel;
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
            doctorModel.doctor.phoneNumber = currentDoctor.phoneNumber;
            doctorModel.surname = user.surname;
            doctorModel.name =  user.name;
            doctorModel.middleName = user.middleName;
            doctorModel.mail = user.mail;
            doctorModel.age = user.Age.ToString();


            var allSpecialities = dbContext.specialitiesTable;

            var allSpeciality = dbContext.specialityTable;

            doctorModel.specialties.AddRange(from speciality in allSpeciality
                                             where allSpecialities.Any(x => x.specialityId == speciality.id && x.doctorId == currentDoctor.id)
                                             select speciality);

            //foreach (var speciality in allSpeciality)
            //{
            //    if (allSpecialities.Any(x => x.specialityId == speciality.id && x.doctorId == currentDoctor.id))
            //    {
            //        doctorModel.specialties.Add(speciality);
            //    }
            //}
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
        }

        public UserProfileModel toUserProFileModel(User user)
        {
           throw new System.NotImplementedException();
        }
    }
}
