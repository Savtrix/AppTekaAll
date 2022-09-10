using AppTeka.Data;
using AppTeka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppTeka.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrugController : ControllerBase
    {
        private readonly DataContext _context;

        public DrugController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Drug>>> Get()
        {
            return Ok(await _context.Drugs.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Drug>> Get(int id)
        {
            var drug = await _context.Drugs.FindAsync(id);
            if (drug == null)
                return BadRequest("Drug not Found");
            return Ok(drug);
        }

        [HttpPost]
        public async Task<ActionResult<List<Drug>>> AddDrug(Drug drug)
        {
            _context.Drugs.Add(drug);
            await _context.SaveChangesAsync();
            return Ok(await _context.Drugs.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Drug>>> UpdateDrug(Drug request)
        {
            var dbDrug = await _context.Drugs.FindAsync(request.Id);
            if (dbDrug == null)
                return BadRequest("Drug not found.");

            dbDrug.Name = request.Name;
            dbDrug.Price = request.Price;
            dbDrug.NeedPrescribtion = request.NeedPrescribtion;

            await _context.SaveChangesAsync();

            return Ok(await _context.Drugs.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Drug>>> Delete(int id)
        {
            var dbDrug = await _context.Drugs.FindAsync(id);
            if (dbDrug == null)
                return BadRequest("Drug not found.");

            _context.Drugs.Remove(dbDrug);
            await _context.SaveChangesAsync();

            return Ok(await _context.Drugs.ToListAsync());
        }
    }
}