using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital.API.Models.Entities
{
    public class Hospital
    {
        [Key]
        public Guid id { get; set; }
        public string name { get; set; }
        public Guid countryId { get; set; }
        [NotMapped]
        public Country country
        {
            get; set;
        }
        public Guid regionId { get; set; }
        [NotMapped]
        public Region region { get; set; }

        public Guid districtId { get; set; }
        [NotMapped]
        public District district { get; set; }

        public Guid settlementId { get; set; }
        [NotMapped]

        public Settlement settlement { get; set; }

        public int typeId { get; set; }
        [NotMapped]
        public Type type { get; set; }

        public string contactNumber { get; set; }

        public string description { get; set; }
    }
}
