using Microsoft.AspNetCore.Mvc;
using AppTeka.Models;

namespace AppTeka.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrugController : ControllerBase
    {


        private readonly ILogger<DrugController> _logger;

        public DrugController(ILogger<DrugController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var Drugs = new List<Drug>()
            {
                new Drug
                {
                DrugId = 1,
                Name = "Apap",
                Price = 9.99,
                NeedPrescribtion = false
                }
            };
            return Ok(Drugs);
        }
    }
}
    
