using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.API.Models.Entities
{
    public class Departament
    {
        [Key]
        public Guid id { get; set; }

        public Guid hospitalId { get; set; }
        [NotMapped]

        public Hospital hospital { get; set; }

        public string name { get; set; }

        public string additionalInformation { get; set; }
        [NotMapped]

        public List<Offices> officesList { get; set; }
    }
}
