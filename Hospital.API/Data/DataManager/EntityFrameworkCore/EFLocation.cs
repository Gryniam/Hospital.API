using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Models.Entities;
using System;
using System.Collections.Generic;

namespace Hospital.API.Data.DataManager.EntityFrameworkCore
{
    public class EFLocation : ILocation
    {
        private readonly HospitalDbContext dbContext;

        public EFLocation(HospitalDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Region> regions => dbContext.regionTable;

        public IEnumerable<District> districts => dbContext.districtTable;

        public IEnumerable<Settlement> settlements => dbContext.settlementTable;

        public District getDistrictBySettlementId(Guid id)
        {
            return dbContext.districtTable.Find(id);
        }

        public Region getRegionByDisctrictId(Guid id)
        {
            return dbContext.regionTable.Find(id);
        }

        public Region getRegionBySettlementId(Guid id)
        {
            Guid districtId = getDistrictBySettlementId(id).id;
            return getRegionByDisctrictId(districtId);
        }

        public Settlement getSettlementById(Guid id)
        {
            return dbContext.settlementTable.Find(id);
        }
    }
}
