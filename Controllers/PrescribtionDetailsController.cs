using AppTeka.Data;
using AppTeka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppTeka.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PrescribtionDetailsController : ControllerBase
    {
        private readonly DataContext _context;

        public PrescribtionDetailsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<PrescribtionDetails>>> Get()
        {
            return Ok(await _context.PrescribtionDetails.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PrescribtionDetails>> Get(int id)
        {
            var PrescribtionDetails = await _context.PrescribtionDetails.FindAsync(id);
            if (PrescribtionDetails == null)
                return BadRequest("Prescribtion Details not Found");
            return Ok(PrescribtionDetails);
        }

        [HttpPost]
        public async Task<ActionResult<List<PrescribtionDetails>>> AddPrescribtionDetails(PrescribtionDetails PrescribtionDetails)
        {
            _context.PrescribtionDetails.Add(PrescribtionDetails);
            await _context.SaveChangesAsync();
            return Ok(await _context.PrescribtionDetails.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<PrescribtionDetails>>> UpdatePrescribtionDetails(PrescribtionDetails request)
        {
            var dbPrescribtionDetails = await _context.PrescribtionDetails.FindAsync(request.Id);
            if (dbPrescribtionDetails == null)
                return BadRequest("Prescribtion Details not found.");

            dbPrescribtionDetails.Quantity = request.Quantity;

            await _context.SaveChangesAsync();

            return Ok(await _context.PrescribtionDetails.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<PrescribtionDetails>>> Delete(int id)
        {
            var dbPrescribtionDetails = await _context.PrescribtionDetails.FindAsync(id);
            if (dbPrescribtionDetails == null)
                return BadRequest("Prescribtion Details not found.");

            _context.PrescribtionDetails.Remove(dbPrescribtionDetails);
            await _context.SaveChangesAsync();

            return Ok(await _context.PrescribtionDetails.ToListAsync());
        }
    }
}