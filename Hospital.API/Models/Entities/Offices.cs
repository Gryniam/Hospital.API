using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.API.Models.Entities
{
    public class Offices
    {
        [Key]
        public Guid id { get; set; }

        public Guid officeId { get; set; }
        [NotMapped]
        public Office office { get; set; }

        public Guid departamentId { get; set; }
    }
}
