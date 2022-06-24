using AppTeka.Data;
using AppTeka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppTeka.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly DataContext _context;

        public DoctorController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Doctor>>> Get()
        {
            return Ok(await _context.Doctors.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> Get(int id)
        {
            var Doctor = await _context.Doctors.FindAsync(id);
            if (Doctor == null)
                return BadRequest("Doctor not Found");
            return Ok(Doctor);
        }

        [HttpPost]
        public async Task<ActionResult<List<Doctor>>> AddDoctor(Doctor Doctor)
        {
            _context.Doctors.Add(Doctor);
            await _context.SaveChangesAsync();
            return Ok(await _context.Doctors.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Doctor>>> UpdateDoctor(Doctor request)
        {
            var dbDoctor = await _context.Doctors.FindAsync(request.Id);
            if (dbDoctor == null)
                return BadRequest("Doctor not found.");

            dbDoctor.Name = request.Name;

            await _context.SaveChangesAsync();

            return Ok(await _context.Doctors.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Doctor>>> Delete(int id)
        {
            var dbDoctor = await _context.Doctors.FindAsync(id);
            if (dbDoctor == null)
                return BadRequest("Doctor not found.");

            _context.Doctors.Remove(dbDoctor);
            await _context.SaveChangesAsync();

            return Ok(await _context.Doctors.ToListAsync());
        }
    }
}