using Hospital.API.Models.Entities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Hospital.API.Data.DataManager.Interfaces
{
    public interface ILocation
    {
        Settlement getSettlementById(Guid id);

        District getDistrictBySettlementId(Guid id);

        Region getRegionByDisctrictId(Guid id);

        Region getRegionBySettlementId(Guid id);

        IEnumerable<Region> regions { get; }

        IEnumerable<District> districts { get;}

        IEnumerable<Settlement> settlements { get; }

        
    }
}
