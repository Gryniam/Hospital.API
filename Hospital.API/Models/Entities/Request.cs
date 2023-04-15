using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Hospital.API.Models.Entities
{
    public class Request
    {
        [Key]
        public Guid id { get; set; }

        public Guid userId { get; set; }

        public Guid specialityId { get; set; }

        public byte[] Document { get; set; }
        [NotMapped]
        public string base64StringPhotoDocument { get; set; }
    }
}
