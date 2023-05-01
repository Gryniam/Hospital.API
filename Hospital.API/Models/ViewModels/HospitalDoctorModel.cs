using System;

namespace Hospital.API.Models.ViewModels
{
    public class HospitalDoctorModel
    {
        public Guid hospitalId { get; set; }    

        public Guid doctorId { get; set; }
    }
}
