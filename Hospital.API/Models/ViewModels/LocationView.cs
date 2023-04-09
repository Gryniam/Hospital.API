using Hospital.API.Models.Entities;
using System.Collections.Generic;

namespace Hospital.API.Models.ViewModels
{
    public class LocationView
    {
        public List<Region> regions { get; set; }

        public List<District> districts { get; set; }

        public List<Settlement> settlements { get; set; }
    }
}
