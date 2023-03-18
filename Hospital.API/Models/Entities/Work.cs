using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.API.Models.Entities
{
    public class Work
    {
        [Key]
        public Guid id { get; set; }

        public Guid doctorId { get; set; }
        [NotMapped]
        public Doctor doctor { get; set; }

        public Guid hospitalId { get; set; }
        [NotMapped]
        public Hospital hospital { get; set; }

        public int statusId { get; set; }
        [NotMapped]
        public Status status { get; set; }

        public bool isAdminInHospital { get; set; }

        public bool isAdminInDepartament { get; set; }

        public Guid departamentId { get; set; }
    }
}
