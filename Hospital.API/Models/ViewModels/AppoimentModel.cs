using Hospital.API.Models.Entities;
using System;

namespace Hospital.API.Models.ViewModels
{
    public class AppoimentModel
    {
        public Guid id { get; set; }

        public RegistrationModel patient { get; set; }

        public Guid patientId { get; set; }    

        public RegistrationModel doctor { get; set; }

        public Guid doctorId { get; set; }

        public Indexes indexesOfPatient { get;set; }

        public string officeName { get; set; }

        public Guid officeId { get; set; }

        public int officeNumberInHospital { get; set; }

        public string officeDesc { get; set; }

        public string hospitalName { get; set; }

        public string Date { get; set; }

    }
}
