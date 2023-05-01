using System;

namespace Hospital.API.Models.ViewModels
{
    public class DoctorOfficesModel
    { 

        public Guid doctorId { get; set; }
        public Guid officeId { get; set; }
        public string date { get; set; }
    }
}
