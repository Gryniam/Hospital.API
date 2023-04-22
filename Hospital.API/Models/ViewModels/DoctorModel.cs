using Hospital.API.Models.Entities;
using System;

namespace Hospital.API.Models.ViewModels
{
    public class DoctorModel
    {
        public Doctor doctor { get; set; }

        public string name { get; set; }

        public string mail { get; set; }

        public string age { get; set; }

        public string phoneNumber { get; set; }
    }
}
