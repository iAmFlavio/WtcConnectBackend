using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WtcConnectBackend.Data;
using WtcConnectBackend.Models;

namespace WtcConnectBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly MongoDbContext _context;

        public CustomersController(MongoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> Get()
        {
            var customers = await _context.Customers.Find(_ => true).ToListAsync();
            return Ok(customers);
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> Post(Customer customer)
        {
            await _context.Customers.InsertOneAsync(customer);
            return CreatedAtAction(nameof(Get), new { id = customer.Id }, customer);
        }
    }
}