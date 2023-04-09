using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Hospital.API.Models.Entities
{
    public class User
    {
        [Key]
        public Guid id { get; set; }
        public string surname { get; set; }
        public string name { get; set; }
        public string middleName { get; set; }
        public string passwordHash { get; set; }
        public string mail { get; set; }
        public int genderId { get; set; }
        public DateTime birthDate { get; set; }
        public int Age { get; set; }
        public bool isAdmin { get; set; }
        [NotMapped]
        public Gender gender { get; set; }

        [AllowNull]
        public Guid userPictureId { get; set; }
        [NotMapped]
        public byte[] userPicture { get; set; }

        public string phoneNumber { get; set; }

        [AllowNull]
        public Guid settlementId { get; set; }
        [NotMapped]
        public Settlement settlement { get; set; }
    }
}
