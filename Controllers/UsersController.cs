using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly BackendContext _context;

        public UsersController(BackendContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] User newUser)
        {
            try
            {
                var duplicatedUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == newUser.Email);

                if (duplicatedUser == null)
                {
                    _context.Users.Add(newUser);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("CreateUser", new { id = newUser.Id }, new
                    {
                        id = newUser.Id,
                        firstName = newUser.FirstName,
                        lastName = newUser.LastName,
                        email = newUser.Email
                    });
                }
                else
                {
                    return BadRequest("Erro ao criar o usuário, email duplicado!");
                }
            }
            catch (System.Exception)
            {
                return BadRequest("Erro ao criar o usuário!");
            }
        }
    }
}
