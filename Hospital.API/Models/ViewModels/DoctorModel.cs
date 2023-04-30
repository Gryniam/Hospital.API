using Hospital.API.Models.Entities;
using System;
using System.Collections.Generic;

namespace Hospital.API.Models.ViewModels
{
    public class DoctorModel
    {
        public Doctor doctor { get; set; }

        public string surname { get; set; }

        public string name { get; set; }

        public string middleName { get; set; }

        public string mail { get; set; }

        public string age { get; set; }

        public List<Specialty> specialties { get; set; }


        public DoctorModel()
        {
            doctor = new Doctor();
            specialties = new List<Specialty>();
        }
    }
}
