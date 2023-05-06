using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.API.Models.Entities
{
    public class Symptoms
    {
        [Key]
        public Guid id { get; set; }

        public Guid diseaseId { get; set; }

        public Guid symptomId { get; set; }

    }
}
