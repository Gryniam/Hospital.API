using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.API.Models.Entities
{
    public class Preparation
    {
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }

        [NotMapped]
        public List<Substance> substances { get; set; }

    }
}
