using Hospital.API.Data;
using Hospital.API.Data.DataManager.Interfaces;
using Hospital.API.Models.Entities;
using Hospital.API.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Hospital.API.Controllers
{
    public class AppoimentManagmentController : Controller
    {
        private readonly HospitalDbContext dbContext;
        private readonly ICast castContext;
        public AppoimentManagmentController(HospitalDbContext dbContext, ICast castContext) 
        { 
            this.dbContext = dbContext;
            this.castContext = castContext;
        }

        [HttpGet("/Appoiment")]
        [Authorize]
        public AppoimentModel getDataOfAppoiment([FromBody] Guid appoimentId)
        {
            Appoiment appoiment = dbContext.appoimentTable.Find(appoimentId);
            AppoimentModel model = castContext.toAppoimentModel(appoiment);

           
            return model;
        }
    }
}
