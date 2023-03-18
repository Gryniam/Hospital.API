using Hospital.API.Data;
using Hospital.API.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital.API.Controllers
{
    [ApiController]
    [Route("api/test/")]
    public class TestController : Controller
    {
        private readonly HospitalDbContext dbContext;

        public TestController(HospitalDbContext context)
        {
            dbContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            return Ok(await dbContext.userTable.ToListAsync());
        }

        [HttpGet]
        [Route("{id:Guid}")]
        [ActionName("GetUserById")]
        public async Task<IActionResult> GetUserById([FromRoute]Guid id)
        {
           // await _context.hospitalTable.FirstOrDefaultAsync(x=>x.id == id);

            var users = await dbContext.userTable.FindAsync(id);
            if(users == null)
            {
                return NotFound();
            }

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            user.id = Guid.NewGuid();

            await dbContext.userTable.AddAsync(user);

            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUserById), new {id = user.id}, user);
        }

        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] User updatedUser)
        {
            var eUser = await dbContext.userTable.FindAsync(id);

            if(eUser == null)
            {
                return NotFound();
            }

            eUser.id = updatedUser.id;
            eUser.surname = updatedUser.surname;
            eUser.name = updatedUser.name;
            eUser.middleName = updatedUser.middleName;
            eUser.passwordHash = updatedUser.passwordHash;
            eUser.mail = updatedUser.mail;
            eUser.gender = updatedUser.gender;

            await dbContext.SaveChangesAsync();

            return Ok(eUser);
        }

        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> DeleteNote([FromRoute] Guid id)
        {
            var eUser = await dbContext.userTable.FindAsync(id);
            if(eUser == null)
            {
                return NotFound();
            }

            dbContext.userTable.Remove(eUser);
            await dbContext.SaveChangesAsync();

            return Ok();
        }
    }

    
}
