using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.API.Models.Entities
{
    public class Allergy
    {
        [Key]
        public Guid id { get; set; }
        public Guid patiendId { get; set; }
        public Guid substanceId {get;set;}
        [NotMapped]
        public Substance substance { get; set; }
    }
}
