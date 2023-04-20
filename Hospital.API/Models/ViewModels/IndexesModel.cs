using System.ComponentModel.DataAnnotations;
using System;

namespace Hospital.API.Models.ViewModels
{
    public class IndexesModel
    {
        public string height { get; set; }
        public string weight { get; set; }
        public string bloodPressure { get; set; }
        public string pulse { get; set; }
        public string bloodSugar { get; set; }
        public string bodyTemperature { get; set; }
        public string additionalInformation { get; set; }
    }
}
