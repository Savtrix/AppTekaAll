using AppTeka.Data;
using AppTeka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppTeka.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescribtionController : ControllerBase
    {
        private readonly DataContext _context;

        public PrescribtionController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Prescribtion>>> Get()
        {
            return Ok(await _context.Prescribtions.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Prescribtion>> Get(int id)
        {
            var Prescribtion = await _context.Prescribtions.FindAsync(id);
            if (Prescribtion == null)
                return BadRequest("Prescribtion not Found");
            return Ok(Prescribtion);
        }

        [HttpPost]
        public async Task<ActionResult<List<Prescribtion>>> AddPrescribtion(Prescribtion Prescribtion)
        {
            _context.Prescribtions.Add(Prescribtion);
            await _context.SaveChangesAsync();
            return Ok(await _context.Prescribtions.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Prescribtion>>> Delete(int id)
        {
            var dbPrescribtion = await _context.Prescribtions.FindAsync(id);
            if (dbPrescribtion == null)
                return BadRequest("Prescribtion not found.");

            _context.Prescribtions.Remove(dbPrescribtion);
            await _context.SaveChangesAsync();

            return Ok(await _context.Prescribtions.ToListAsync());
        }
    }
}