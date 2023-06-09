﻿using Hospital.API.Models.Entities;
using Hospital.API.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace Hospital.API.Data.DataManager.Interfaces
{
    public interface ICast
    {
        Indexes fromIndexesModel(IndexesModel indexesModel);
        RegistrationModel toRegistrationModel(User user);
        
        UserProfileModel toUserProFileModel(User user);

        AppoimentModel toAppoimentModel(Appoiment appoiment);

        CaseModel toCaseModel(Case currentCase);

        Case fromCaseModel(CaseModel caseModel);

        EditProfileModel toEditProfileModel(User user);

        HospitalModel toHospitalModel(Models.Entities.Hospital hospital);

        DoctorModel toDoctorModel(Doctor currentDoctor);
    }
}
