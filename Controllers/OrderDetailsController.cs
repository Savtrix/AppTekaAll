using AppTeka.Data;
using AppTeka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppTeka.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderDetailsController : ControllerBase
    {
        private readonly DataContext _context;

        public OrderDetailsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<OrderDetails>>> Get()
        {
            return Ok(await _context.OrderDetails.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDetails>> Get(int id)
        {
            var OrderDetails = await _context.OrderDetails.FindAsync(id);
            if (OrderDetails == null)
                return BadRequest("OrderDetails not Found");
            return Ok(OrderDetails);
        }

        [HttpPost]
        public async Task<ActionResult<List<OrderDetails>>> AddOrderDetails(OrderDetails OrderDetails)
        {
            _context.OrderDetails.Add(OrderDetails);
            await _context.SaveChangesAsync();
            return Ok(await _context.OrderDetails.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<OrderDetails>>> UpdateOrderDetails(OrderDetails request)
        {
            var dbOrderDetails = await _context.OrderDetails.FindAsync(request.Id);
            if (dbOrderDetails == null)
                return BadRequest("OrderDetails not found.");

            dbOrderDetails.Quantity = request.Quantity;

            await _context.SaveChangesAsync();

            return Ok(await _context.OrderDetails.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<OrderDetails>>> Delete(int id)
        {
            var dbOrderDetails = await _context.OrderDetails.FindAsync(id);
            if (dbOrderDetails == null)
                return BadRequest("OrderDetails not found.");

            _context.OrderDetails.Remove(dbOrderDetails);
            await _context.SaveChangesAsync();

            return Ok(await _context.OrderDetails.ToListAsync());
        }
    }
}