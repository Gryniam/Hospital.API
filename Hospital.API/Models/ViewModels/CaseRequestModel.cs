using System;

namespace Hospital.API.Models.ViewModels
{
    public class CaseRequestModel
    {
        public Guid appoimentId { get; set; }
        public Guid patientId { get; set; }
        
        public Guid doctorId { get; set; }

        public Guid diseaseId { get; set; }
        
        public Guid officeId { get; set; }
    }
}
