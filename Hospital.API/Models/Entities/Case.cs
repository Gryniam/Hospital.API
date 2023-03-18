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
        [NotMapped]
        public Patient patient { get; set; }

        public Guid doctorId { get; set; }
        [NotMapped]
        public Doctor doctor { get; set; }

        public Guid diseaseId { get; set; }
        [NotMapped]
        public Disease disease { get; set; }

        public Guid caseStatusId {get;set;}
        [NotMapped]
        public CaseStatus caseStatus { get; set; }

        public Guid officeId { get; set; }
        [NotMapped]
        public Office office { get; set; }

        public string anamnesis { get; set; }
        [AllowNull]
        public string treatmentInformation { get; set; }
        [NotMapped]
        public List<Treatment> treatment { get; set; }

        public DateTime createDate { get; set; }
    }
}
