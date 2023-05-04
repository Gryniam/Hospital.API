using Hospital.API.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Microsoft.VisualBasic;

namespace Hospital.API.Models.ViewModels
{
    public class SendingModel
    {
        public string doctorId { get; set; }
        public string appoimentTimeId { get; set; }
        public string officeId { get; set; }
        public string date { get; set; }
        public string additionalInformation { get; set; }
    }
}
