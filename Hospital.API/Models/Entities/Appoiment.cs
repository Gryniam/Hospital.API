using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.API.Models.Entities
{
    public class Appoiment
    {
        public Guid id { get; set; }
        public Guid patientId { get; set; }
        public Guid doctorId { get; set; }
        public Guid appoimentTimeId { get; set; }
        public Guid officeId { get; set; }

        [NotMapped]
        public Office office { get; set;}

        public DateTime dateTime { get; set; }

        [NotMapped]
        public string date { get; set; }

    }
}
