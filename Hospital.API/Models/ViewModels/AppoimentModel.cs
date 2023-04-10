using Hospital.API.Models.Entities;
using System;

namespace Hospital.API.Models.ViewModels
{
    public class AppoimentModel
    {
        public Guid id { get; set; }

        public string patientName { get; set; }

        public string doctorName { get; set; }

        public Indexes indexesOfPatient { get;set; }

        public string officeName { get; set; }

        public int officeNumberInHospital { get; set; }

        public string officeDesc { get; set; }

        public string hospitalName { get; set; }

        public DateTime Date { get; set; }

    }
}
