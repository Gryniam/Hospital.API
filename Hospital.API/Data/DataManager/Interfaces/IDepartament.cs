using Hospital.API.Models.Entities;
using System;
using System.Collections.Generic;

namespace Hospital.API.Data.DataManager.Interfaces
{
    public interface IDepartament
    {

        IEnumerable<Departament> departaments { get; }

        IEnumerable<Departament> getDepartamentsByOwnerId(Guid ownerId);


    }
}
