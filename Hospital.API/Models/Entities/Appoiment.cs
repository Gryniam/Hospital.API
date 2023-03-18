using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.API.Models.Entities
{
    public class Appoiment
    {
        public Guid id { get; set; }
        public Guid patientId { get; set; }
        [NotMapped]
        public Patient patient { get; set; }
        public Guid doctorId { get; set; }
        [NotMapped]
        public Doctor doctor { get; set; }

        public Guid timeId { get; set; }
        [NotMapped]
        public TimeOnly timeOnly { get; set; }
        public Guid officeId { get; set; }
        [NotMapped]
        public Office office { get; set;}

        public DateTime dateTime { get; set; }

    }
}
