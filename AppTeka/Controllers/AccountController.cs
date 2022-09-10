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

        [HttpGet("{Id}/{Password}/1")]
        public async Task<ActionResult<Account>> Get(string Id, string Password)
        {
            var Account = await _context.Accounts.FindAsync(Id);
            if (Account == null)
                return BadRequest("Account Not Found");
            if (Account.Password != Password)
                return BadRequest("Wrong Password");
            return Ok(Account);
        }

        [HttpPost]
        public async Task<ActionResult<List<Doctor>>> CheckAccount(Account account)
        {
            var Account = await _context.Accounts.FindAsync(account.Id);
            if (Account == null)
                return BadRequest("Account Not Found");
            if (Account.Password.Replace(" ","") != account.Password)
                return BadRequest("Wrong Password");
            return Ok(Account);
        }
    }
}