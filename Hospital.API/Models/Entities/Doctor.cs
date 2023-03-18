using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.API.Models.Entities
{
    public class Doctor
    {
        [Key]
        public Guid id { get; set; }
        public Guid userId { get; set; }
        [NotMapped]
        public User user { get; set; }

        public string additionalInformation { get; set; }
        public string phoneNumber { get; set; }

    }
}
