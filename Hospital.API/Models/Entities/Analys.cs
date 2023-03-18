using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.API.Models.Entities
{
    public class Analys
    {
        [Key]
        public Guid id { get; set; }
        public Guid caseId { get; set; }
        [NotMapped]
        public Case _case { get; set; }

        public Guid officeId { get; set; }
        [NotMapped]
        public Office office { get; set; }

        public byte[] picture { get; set; }
        public string additionalInformation { get; set; }

        public DateTime createDate { get; set; }
    }
}
