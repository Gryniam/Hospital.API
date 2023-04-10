using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.API.Models.Entities
{
    public class Time
    {
        public Guid id { get; set; }

        public Guid doctorId { get; set; }

        [NotMapped]
        public Doctor doctor { get; set; }
        public string time { get; set; }
    }
}
