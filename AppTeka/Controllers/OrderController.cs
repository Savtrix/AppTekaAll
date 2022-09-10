using AppTeka.Data;
using AppTeka.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppTeka.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly DataContext _context;

        public OrderController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Order>>> Get()
        {
            return Ok(await _context.Orders.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            var Order = await _context.Orders.FindAsync(id);
            if (Order == null)
                return BadRequest("Order not Found");
            return Ok(Order);
        }

        [HttpPost]
        public async Task<ActionResult<List<Order>>> AddOrder(Order Order)
        {
            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();
            return Ok(await _context.Orders.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Order>>> UpdateOrder(Order request)
        {
            var dbOrder = await _context.Orders.FindAsync(request.Id);
            if (dbOrder == null)
                return BadRequest("Order not found.");

            dbOrder.Sum = request.Sum;
            dbOrder.PrescribtionId = request.PrescribtionId;
            dbOrder.ShopAssistantId = request.ShopAssistantId;
            dbOrder.CompletionDate = request.CompletionDate;
            await _context.SaveChangesAsync();

            return Ok(await _context.Orders.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Order>>> Delete(int id)
        {
            var dbOrder = await _context.Orders.FindAsync(id);
            if (dbOrder == null)
                return BadRequest("Order not found.");

            _context.Orders.Remove(dbOrder);
            await _context.SaveChangesAsync();

            return Ok(await _context.Orders.ToListAsync());
        }
    }
}