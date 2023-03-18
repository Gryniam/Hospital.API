using System;
using System.ComponentModel.DataAnnotations;

namespace Hospital.API.Models.Entities
{
    public class Preparations
    {
        [Key]
        public Guid id { get; set; }
        public Guid preparationId { get; set; }
        public Guid substanceId { get; set; }

    }
}
