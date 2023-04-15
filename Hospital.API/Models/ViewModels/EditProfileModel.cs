using Hospital.API.Models.Entities;
using System.Collections.Generic;

namespace Hospital.API.Models.ViewModels
{
    public class EditProfileModel
    {
        public RegistrationModel registrationModel { get; set; }

        public string currentRegionName { get; set; }
        public string currentDistrictName { get; set; }

        public List<Substance> noAllergySubstance { get; set; }

        public List<Substance> AllergySubstance { get; set; }

        public List<Region> regions { get; set; }   

        public List<District> districts { get; set; }

        public List<Settlement> settlements { get; set;}
    }
}
