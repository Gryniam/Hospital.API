using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital.API.Models.Entities
{
    public class Indexes
    {
        [Key]
        public Guid id { get; set; }
        public Guid patiendId { get; set; }
        public float height { get; set; }
        public float weight { get; set; }
        public string bloodPressure { get; set; }
        public int pulse { get; set; }
        public float bloodSugar { get; set; }
        public float bodyTemperature { get; set; }
        public string additionalInformation { get; set; }

    }
}
