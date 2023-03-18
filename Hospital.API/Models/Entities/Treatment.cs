using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.API.Models.Entities
{
    public class Treatment
    {
        [Key]
        public Guid id { get; set; }

        public Guid caseId { get; set; }

        public Guid preparationId { get; set; }
        [NotMapped]

        public Preparation preparation { get; set; }
        
    }
}
