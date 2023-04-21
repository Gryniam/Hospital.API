using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var districtId = dbContext.settlementTable.Find(id).districtId;
            return dbContext.districtTable.Find(districtId);
        }

        public Region getRegionByDisctrictId(Guid id)
        {
            var regionId = dbContext.districtTable.Find(id).regionId;
            return dbContext.regionTable.Find(regionId);
        }

        public Region getRegionBySettlementId(Guid id)
        {
            var districtId = getDistrictBySettlementId(id).id;
            var regionId = dbContext.districtTable.Find(districtId).regionId;
            return dbContext.regionTable.Find(regionId);
        }

        public Settlement getSettlementById(Guid id)
        {
            return dbContext.settlementTable.Find(id);
        }
    }
}
