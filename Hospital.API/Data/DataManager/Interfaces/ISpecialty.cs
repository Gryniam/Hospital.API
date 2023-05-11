using Hospital.API.Models.Entities;
using System.Collections;
using System.Collections.Generic;

namespace Hospital.API.Data.DataManager.Interfaces
{
    public interface ISpecialty
    {
       
        IEnumerable<Specialty> getSpecialityTable { get; }
    }
}
