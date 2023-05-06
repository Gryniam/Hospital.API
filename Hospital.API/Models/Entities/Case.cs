using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Hospital.API.Models.Entities
{
    public class Case
    {
        [Key]
        public Guid id { get; set; }

        public Guid patientId { get; set; }

        public Guid doctorId { get; set; }
        public Guid diseaseId { get; set; }
        public Guid caseStatusId {get;set;}
        public Guid officeId { get; set; }
        public string anamnesis { get; set; }
        [AllowNull]
        public string treatmentInformation { get; set; }
        [NotMapped]
        public List<Treatment> treatment { get; set; }

        public DateTime createDate { get; set; }
    }
}
