﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.API.Models.Entities
{
    public class Times
    {
        [Key]
        public Guid Id { get; set; }


        public Guid doctorId { get; set; }

        [NotMapped]
        public Doctor doctor { get; set; }

        public Guid timeId { get; set; }

        [NotMapped]
        public Time time { get; set; }

        public Guid officeId { get; set; }
    }
}
