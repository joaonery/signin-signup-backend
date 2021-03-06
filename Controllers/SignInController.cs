using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Backend.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SignInController : ControllerBase
    {
        private readonly BackendContext _context;

        public SignInController(BackendContext context)
        {
            _context = context;
        }

        // POST: api/SignIn
        [HttpPost]
        public async Task<ActionResult<User>> SignIn([FromHeader] string email, [FromHeader] string password)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

                if (user != null)
                {
                    return Ok(new { accessToken = "123456789" });
                }
                else
                {
                    return BadRequest("Email ou senha incorretos!");
                }
            }
            catch (System.Exception)
            {
                return BadRequest("Erro ao autenticar!");
            }
        }
    }
}
