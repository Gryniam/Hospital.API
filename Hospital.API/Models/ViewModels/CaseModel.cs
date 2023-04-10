using Hospital.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Hospital.API.Models.ViewModels
{
    public class CaseModel
    {
        public Guid id { get; set; }

        public string patientName { get; set;}
        public string diseaseName { get;set; }
        public string caseStatus { get; set; }

        public Guid officeId { get; set; }

        public Office office { get; set; }

        public string hospitalName { get; set; }

        public string anamnesis { get; set; }
        public string treatmentInformation { get; set; }

        public string createDate { get; set; }
    }
}
