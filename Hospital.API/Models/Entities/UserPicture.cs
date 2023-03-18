using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.API.Models.Entities
{
    public class UserPicture
    {
        [Key]
        public Guid id { get; set; }
        public byte[] picture { get; set; }
        [NotMapped]
        public string base64StringPhoto { get; set; }
    }
}
