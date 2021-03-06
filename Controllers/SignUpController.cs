using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly BackendContext _context;

        public SignUpController(BackendContext context)
        {
            _context = context;
        }

        // POST: api/SignUp
        [HttpPost]
        public async Task<ActionResult<User>> SignUp([FromBody] User newUser)
        {
            try
            {
                var duplicatedUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == newUser.Email);

                if (duplicatedUser == null)
                {
                    _context.Users.Add(newUser);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("SignUp", new { id = newUser.Id }, new
                    {
                        userName = newUser.UserName,
                        email = newUser.Email,
                        name = newUser.Name
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
