using Hospital.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.API.Controllers
{
    public class AppoimentManagmentController : Controller
    {
        private readonly HospitalDbContext dbContext;
        public AppoimentManagmentController(HospitalDbContext dbContext) 
        { 
            this.dbContext = dbContext;
        }

    }
}
