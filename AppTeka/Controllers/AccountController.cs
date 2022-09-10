using AppTeka.Data;
using AppTeka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppTeka.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly DataContext _context;

        public AccountController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("{Name}/{Password}")]
        public async Task<ActionResult<Account>> Get(string Name, string Password)
        {
            var Account = await _context.Accounts.FindAsync(Name);

            if (Account.Password != Password)
                return BadRequest("Wrong Password");
            return Ok();
        }
    }
}