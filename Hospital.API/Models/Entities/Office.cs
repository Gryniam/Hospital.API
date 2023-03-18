using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital.API.Models.Entities
{
    public class Office
    {
        [Key]
        public Guid id { get; set; }

        public string name { get; set; }

        public int numberInHospital { get; set; }

        public string additionalInformation { get; set; }

    }
}
