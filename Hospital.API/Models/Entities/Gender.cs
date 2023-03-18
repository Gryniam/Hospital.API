using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital.API.Models.Entities
{
    public class Gender
    {
        [Key]
        public int id { get; set; }
        public string genderName { get; set; }
    }
}
