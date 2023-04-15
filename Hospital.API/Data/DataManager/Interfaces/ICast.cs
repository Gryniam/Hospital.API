using Hospital.API.Models.Entities;
using Hospital.API.Models.ViewModels;
using System.Collections.Generic;

namespace Hospital.API.Data.DataManager.Interfaces
{
    public interface ICast
    {
        RegistrationModel toRegistrationModel(User user);
        
        UserProfileModel toUserProFileModel(User user);

        AppoimentModel toAppoimentModel(Appoiment appoiment);

        CaseModel toCaseModel(Case currentCase);

        EditProfileModel toEditProfileModel(User user);
    }
}
