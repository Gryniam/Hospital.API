using System;

namespace Hospital.API.Models.ViewModels
{
    public class HospitalModel
    {
        public Guid id { get; set; }

        public string name { get; set; }

        public string regionDesc { get; set; }

        public string disctrictDesc { get; set; }   

        public string settlementDesc { get; set; }
        
        public string TypeDesc { get; set; }

        public string contactNumber { get; set; }

        public string adressDesc { get; set; }

        public string additionalInformation { get; set; }
    }
}
