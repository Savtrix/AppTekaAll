using AppTeka.Data;
using AppTeka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppTeka.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShopAssistantController : ControllerBase
    {
        private readonly DataContext _context;

        public ShopAssistantController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<ShopAssistant>>> Get()
        {
            return Ok(await _context.ShopAssistants.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShopAssistant>> Get(int id)
        {
            var ShopAssistant = await _context.ShopAssistants.FindAsync(id);
            if (ShopAssistant == null)
                return BadRequest("Shop Assistant not Found");
            return Ok(ShopAssistant);
        }

        [HttpPost]
        public async Task<ActionResult<List<ShopAssistant>>> AddShopAssistant(ShopAssistant ShopAssistant)
        {
            _context.ShopAssistants.Add(ShopAssistant);
            await _context.SaveChangesAsync();
            return Ok(await _context.ShopAssistants.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<ShopAssistant>>> UpdateShopAssistant(ShopAssistant request)
        {
            var dbShopAssistant = await _context.ShopAssistants.FindAsync(request.Id);
            if (dbShopAssistant == null)
                return BadRequest("Shop Assistant not found.");

            dbShopAssistant.Name = request.Name;

            await _context.SaveChangesAsync();

            return Ok(await _context.ShopAssistants.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<ShopAssistant>>> Delete(int id)
        {
            var dbShopAssistant = await _context.ShopAssistants.FindAsync(id);
            if (dbShopAssistant == null)
                return BadRequest("Shop Assistant not found.");

            _context.ShopAssistants.Remove(dbShopAssistant);
            await _context.SaveChangesAsync();

            return Ok(await _context.ShopAssistants.ToListAsync());
        }
    }
}