using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.API.Models.Entities
{
    public class Patient
    {
        [Key]
        public Guid id { get; set; }
        public Guid UserId { get; set; }
        [NotMapped]
        public User user { get; set; }
        [NotMapped]
        public List<Allergy> allergies { get; set; }

    }
}
