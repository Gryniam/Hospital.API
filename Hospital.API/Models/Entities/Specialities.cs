using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital.API.Models.Entities
{
    public class Specialities
    {
        [Key]
        public Guid Id { get; set; }

        public Guid doctorId { get; set; }

        public Guid specialityId { get; set; }
    }
}
