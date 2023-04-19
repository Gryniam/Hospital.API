using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital.API.Models.Entities
{
    public class Specialty
    {
        [Key]
        public Guid id { get; set; }

        public string Name { get; set; }
    }
}
